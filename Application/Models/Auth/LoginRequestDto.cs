using System;

namespace Application.Models.Auth;

public class LoginRequestDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}
