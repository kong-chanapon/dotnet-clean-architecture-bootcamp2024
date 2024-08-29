using Application.Models.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Features.Auth.Commands.Login;

public class LoginHandler : IRequestHandler<LoginCommand, LoginResponseDto>
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IConfiguration _configuration;

    public LoginHandler(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public LoginHandler(UserManager<IdentityUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<LoginResponseDto> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var identityUser = await _userManager.FindByEmailAsync(command.Request.Email);
        if(identityUser is null){
            return null;
        }

        var checkPasswordResult = await _userManager.CheckPasswordAsync(identityUser, command.Request.Password);
        if(checkPasswordResult is false){
            return null;
        }

        var roles = await _userManager.GetRolesAsync(identityUser);

        var token = GenereateJwtToken(identityUser, roles);

        var result = new LoginResponseDto {
            Email = identityUser.Email,
            Roles = roles.ToList(),
            Token = token
        };

        return result;
    }

    public string GenereateJwtToken(IdentityUser identityUser, IList<string> roles) 
    {
        var claims = new List<Claim> {
            new Claim(ClaimTypes.Email, identityUser.Email)
        };

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
