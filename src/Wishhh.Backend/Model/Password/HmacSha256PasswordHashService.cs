using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Wishhh.Backend.Model.Password;

public class HmacSha256PasswordHashService : IPasswordHashService
{
    public async Task<byte[]> GenerateSaltAsync(int bytesCount)
    {
        // Generate a 128-bit salt using a sequence of
        // cryptographically strong random bytes.
        var salt = RandomNumberGenerator.GetBytes(bytesCount);
        return await Task.FromResult(salt);
    }
    
    public async Task<string> GetHashAsync(string password, byte[] salt)
    {
        // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
        var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

        return await Task.FromResult(hashed);
    }
}