namespace Wishhh.Backend.Services.Auth;

public record SignUpRequest(string Username, string Password, string DisplayName, IFormFile Image);

public record SignedUpResult(string UserId);

public record SignUpFailed(SignUpFailedReason Reason, string? Message);

public enum SignUpFailedReason
{
    UsernameTaken,
    UsernameValidationError,
    PasswordValidationError,
    WeakPassword,
}