using System;
using Application.Models.Auth;
using MediatR;

namespace Application.Features.Auth.Commands;

public class RegisterCommand:IRequest<bool>
{
    public RegisterRequestDto Request{get; set;}

    public RegisterCommand(RegisterRequestDto request)
    {
        Request = request;
    }
}