using Wishhh.Backend.Infrastructure;
using Wishhh.Backend.Model;
using Wishhh.Backend.Model.Password;
using Wishhh.Backend.Repositories.Images;
using Wishhh.Backend.Repositories.Users;

namespace Wishhh.Backend.Services;

public interface IUserService
{
    public Task<User> CreateUserAsync(string username, string password, string displayName);

    public Task<CheckCredentialsResult> CheckCredentialsAsync(string username, string password);

    public Task<bool> TrySetUsersImageAsync(string userId, IFormFile image);

    public Task RemoveUsersImageAsync(string userId);

    public Task<bool> TryRemoveUserAsync(string userId);

    public Task<User?> GetUserByIdAsync(string userId);

    public Task<User?> GetUserByUsernameAsync(string username);

    public Task<User> UpdateUserAsync(User user);
}

public class UserService : IUserService
{
    private readonly IUserRepository _users;
    private readonly IImageRepository _images;
    private readonly IPasswordHashService _passwordHasher;

    public UserService(
        IUserRepository users,
        IImageRepository images,
        IPasswordHashService passwordHasher)
    {
        _users = users;
        _images = images;
        _passwordHasher = passwordHasher;
    }

    public async Task<User> CreateUserAsync(
        string username,
        string password,
        string displayName)
    {
        var salt = await _passwordHasher.GenerateSaltAsync();
        var hashedPassword = await _passwordHasher.GetHashAsync(password, salt);

        var request = new CreateUserRequest(
            username,
            hashedPassword,
            Convert.ToBase64String(salt),
            displayName);

        return await _users.CreateUserAsync(request);
    }

    public async Task<CheckCredentialsResult> CheckCredentialsAsync(
        string username,
        string password)
    {
        var user = await _users.GetUserByUsernameAsync(username);
        if (user is null)
            return CheckCredentialsResult.UserNotFound();

        var hashedPassword =
            await _passwordHasher.GetHashAsync(password, Convert.FromBase64String(user.PasswordSalt));

        return hashedPassword == user.PasswordHash 
            ? CheckCredentialsResult.Success(user) 
            : CheckCredentialsResult.WrongPassword();
    }

    public async Task<bool> TrySetUsersImageAsync(string userId, IFormFile image)
    {
        var user = await _users.GetUserByIdAsync(userId);
        if (user is null)
            return false;

        await SetImageForUserAsync(user, image);
        return true;
    }

    private async Task SetImageForUserAsync(User user, IFormFile image)
    {
        if (user.ImagePath is not null) 
            await _images.DeleteImageAsync(user.ImagePath);

        var path = ImageHelper.GetUserImagePath(user.Id, Guid.NewGuid().ToString());
        await _images.UploadImageAsync(image, path);
        user = user with { ImagePath = path };
        _ = await _users.UpdateUserAsync(user);
    }

    public async Task RemoveUsersImageAsync(string userId)
        => await _images.DeleteImageAsync($"users/{userId}");

    public async Task<bool> TryRemoveUserAsync(string userId)
        => await _users.TryRemoveUserAsync(userId);

    public Task<User?> GetUserByIdAsync(string userId)
        => _users.GetUserByIdAsync(userId);

    public Task<User?> GetUserByUsernameAsync(string username) =>
        _users.GetUserByUsernameAsync(username);

    public Task<User> UpdateUserAsync(User user)
        => _users.UpdateUserAsync(user);
}

public record CheckCredentialsResult(bool? UserFound, bool? PasswordValid)
{
    public User? User { get; init; } = null!;
    
    public bool Ok => UserFound.HasValue && UserFound.Value && 
                      PasswordValid.HasValue && PasswordValid.Value;

    public static CheckCredentialsResult UserNotFound() => new(false, null);

    public static CheckCredentialsResult Success(User user) => new(true, true) { User = user };

    public static CheckCredentialsResult WrongPassword() => new(true, false);
}