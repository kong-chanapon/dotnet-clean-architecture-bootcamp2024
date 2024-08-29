using System;
using Application.Models.Auth;
using MediatR;

namespace Application.Features.Auth.Commands.Login;

public class LoginCommand:IRequest<LoginResponseDto>
{
    public LoginRequestDto Request{get; set;}
    public LoginCommand(LoginRequestDto request)
    {
        Request = request;
    }

}
