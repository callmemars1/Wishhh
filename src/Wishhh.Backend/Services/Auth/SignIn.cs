namespace Wishhh.Backend.Services.Auth;

public record SignInRequest(string Username, string Password);

public record SignedInResult(string Token);

public record SignInFailed(SignInFailedReason Reason, string? Message);

public enum SignInFailedReason
{
    UserNotFound,
    WrongPassword,
}