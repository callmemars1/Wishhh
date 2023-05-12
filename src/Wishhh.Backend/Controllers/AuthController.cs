using Microsoft.AspNetCore.Mvc;
using Wishhh.Backend.Services.Auth;

namespace Wishhh.Backend.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("sign-up")]
    public async Task<IResult> SignUpAsync(SignUpRequestDto request)
    {
        
    }

    [HttpPost("sign-in")]
    public async Task<IResult> SignInAsync(SignInRequestDto request) => Results.Empty;
    
    [HttpPost("sing-out")]
    public async Task<IResult> SignOutAsync(SignOutRequestDto request) => Results.Empty;
}

public record SignUpRequestDto
{
    public string Username { get; init; }
    public string Password { get; init; }
    public string DisplayName { get; init; }
    public IFormFile Image { get; init; }
}

public record SignInRequestDto
{
    public string Username { get; init; }
    public string Password { get; init; }
}

public class SignOutRequestDto
{
}
