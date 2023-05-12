namespace Wishhh.Backend.Model.Images;

public record GoogleStorageOptions
{
    public string CredentialsJson { get; init; } = null!;
    
    public string BucketName { get; init; } = null!;
}