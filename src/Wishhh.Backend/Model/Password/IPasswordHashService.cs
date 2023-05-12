namespace Wishhh.Backend.Model.Password;

public interface IPasswordHashService
{
    public Task<byte[]> GenerateSaltAsync(int bytesCount);

    public Task<string> GetHashAsync(string password, byte[] salt);
}