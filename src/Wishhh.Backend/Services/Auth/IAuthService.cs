using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OneOf;

namespace Wishhh.Backend.Services.Auth;

public interface IAuthService
{
    public Task<OneOf<SignedUpResult, SignUpFailed>> SignUpAsync(SignUpRequest request);

    public Task<OneOf<SignedInResult, SignInFailed>> SignInAsync(SignInRequest request);

    public Task<OneOf<SignedOutResult>> SignOutAsync(SignOutRequest request);
}

public class JwtSettings
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public SecurityKey Key { get; set; }
}

class AuthService : IAuthService
{
    private readonly IOptionsMonitor<JwtSettings> _jwtSettings;

    public AuthService(IOptionsMonitor<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings;
    }
    
    public Task<OneOf<SignedUpResult, SignUpFailed>> SignUpAsync(SignUpRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<OneOf<SignedInResult, SignInFailed>> SignInAsync(SignInRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<OneOf<SignedOutResult>> SignOutAsync(SignOutRequest request)
    {
        throw new NotImplementedException();
    }
}