using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wishhh.Backend.Infrastructure;
using Wishhh.Backend.Model;
using Wishhh.Backend.Model.Auth;
using Wishhh.Backend.Repositories.Images;
using Wishhh.Backend.Services;

namespace Wishhh.Backend.Controllers;

[Authorize]
[ApiController]
[Route("api/users")]
public class UsersController : Controller
{
    private readonly IUserService _userService;
    private readonly IImageRepository _images;

    public UsersController(IUserService userService, IImageRepository images)
    {
        _userService = userService;
        _images = images;
    }

    [HttpGet("info")]
    public async Task<IResult> GetUserInfo()
    {
        var claim = HttpContext.User.FindFirst(c => c.Type == AuthClaims.UserId)!;
        var user = await _userService.GetUserByIdAsync(claim.Value);
        if (user is null)
            Results.NotFound();

        var userImageUri = await _images.GetImageUriAsync(user!.ImagePath!);
        return Results.Json(new UserInfoDto(
            user.Id, user.Username, user.DisplayName, userImageUri));
    }

    [HttpPost("set-avatar")]
    public async Task<IResult> SetAvatar([FromForm(Name = "Image")] IFormFile image)
    {
        var claim = HttpContext.User.FindFirst(c => c.Type == AuthClaims.UserId)!;
        var result = await _userService.TrySetUsersImageAsync(claim.Value, image);
        return result ? Results.StatusCode(200) : Results.NotFound();
    }

    [HttpPost("set-name")]
    public async Task<IResult> SetName(
        [FromBody] SetNameRequestDto request,
        [FromServices] IValidator<SetNameRequestDto> requestValidator)
    {
        var validationResult = await requestValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
            return Results.ValidationProblem(validationResult.ToDictionary());
        
        var claim = HttpContext.User.FindFirst(c => c.Type == AuthClaims.UserId)!;
        var user = await _userService.GetUserByIdAsync(claim.Value);
        if (user is null)
            Results.NotFound();

        user = user! with { DisplayName = request.DisplayName };
        _ = _userService.UpdateUserAsync(user);
        return Results.StatusCode(200);
    }
}

public record UserInfoDto(string Id, string Username, string DisplayName, Uri? ImageUri);

public record SetNameRequestDto(string DisplayName);