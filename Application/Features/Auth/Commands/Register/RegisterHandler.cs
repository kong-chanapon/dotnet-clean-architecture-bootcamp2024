using System;
using Application.Models.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Auth.Commands;

public class RegisterHandler : IRequestHandler<RegisterCommand, bool>
{
    private readonly UserManager<IdentityUser> _userManager;

    public RegisterHandler(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var user = new IdentityUser {
            UserName = command.Request.Email.Trim(),
            Email = command.Request.Email.Trim()
        };

        var identityResult = await _userManager.CreateAsync(user, command.Request.Password);

        if(identityResult.Succeeded is false){
            return false;
        }

        identityResult = await _userManager.AddToRolesAsync(user, ["Reader", "Writer"]);

        if (identityResult.Succeeded is false) {
                        return false;
        }

        return true;
    }
}
