using Microsoft.AspNetCore.Mvc;
using Wishhh.Backend.Model.Auth;
using Wishhh.Backend.Repositories.Users;

namespace Wishhh.Backend.Controllers;

[ApiController]
[Route("api/wishlists")]
public class WishlistsController : Controller
{
    private readonly IUserRepository _userRepository;

    public WishlistsController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<IResult> GetWishlistsAsync()
    {
        var claim = HttpContext.User.FindFirst(c => c.Type == AuthClaims.UserId);
        if (claim is null)
            Results.NotFound();
        
        return Results.Json(await _userRepository.GetWishlistsOfUserById(claim.Value));
    }
}

public record WishlistInfoDto(string Name, bool Private, string ImageUri);