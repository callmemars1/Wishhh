using System.Security.Claims;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wishhh.Backend.Model.Auth;
using Wishhh.Backend.Services;

namespace Wishhh.Backend.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : Controller
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("sign-up")]
    public async Task<IResult> SignUpAsync(
        [FromBody] SignUpRequestDto request,
        [FromServices] IValidator<SignUpRequestDto> requestValidator)
    {
        var validationResult = await requestValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
            return Results.ValidationProblem(validationResult.ToDictionary());

        try
        {
            var user =
                await _userService.CreateUserAsync(request.Username, request.Password, request.DisplayName);
            return Results.Json(new SignUpSuccessful(user.Id));
        }
        catch (Exception e)
        {
            return Results.Problem(e.Message);
        }
    }

    [HttpPost("sign-in")]
    public async Task<IResult> SignInAsync([FromBody] SignInRequestDto request)
    {
        var checkCredentialsResult =
            await _userService.CheckCredentialsAsync(request.Username, request.Password);

        if (!checkCredentialsResult.Ok)
            return Results.ValidationProblem(checkCredentialsResult.ToErrorsDictionary()!);

        var claims = new[]
        {
            new Claim(AuthClaims.UserId, checkCredentialsResult.User!.Id)
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            new AuthenticationProperties
            {
                IsPersistent = true,
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30),
                IssuedUtc = DateTimeOffset.UtcNow,
            });

        return Results.StatusCode(200);
    }

    [HttpPost("sign-out")]
    public async Task<IResult> SignOutAsync()
    {
        await HttpContext.SignOutAsync();
        return Results.StatusCode(200);
    }

    [Authorize]
    [HttpGet("auth-check")]
    public IResult AuthCheck() => Results.StatusCode(200);
}

public record SignUpRequestDto(string Username, string Password, string DisplayName);

public record SignUpSuccessful(string UserId);


public record SignInRequestDto(string Username, string Password);

public static class CheckCredentialsResultHelper
{
    public static Dictionary<string, string[]>? ToErrorsDictionary(this CheckCredentialsResult result)
    {
        if (result.Ok)
            return null;

        var dict = new Dictionary<string, string[]>();
        
        if (result.UserFound.HasValue && !result.UserFound.Value) 
            dict.Add(nameof(SignInRequestDto.Username), new [] { "Пользователь не найден!" });
        
        if (result.PasswordValid.HasValue && !result.PasswordValid.Value) 
            dict.Add(nameof(SignInRequestDto.Password), new [] { "Пароль не совпадает!" });

        return dict;
    }
}