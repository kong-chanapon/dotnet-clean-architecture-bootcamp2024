using System;

namespace Application.Models.Auth;

public class RegisterRequestDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}
