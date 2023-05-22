namespace Wishhh.Backend.Model;

public record FirebaseOptions
{
    public required string CredentialsJson { get; init; } = null!;
    
    public required string StorageBucketName { get; init; } = null!;

    public required string ProjectId { get; init; } = null!;

    public required string CollectionName { get; init; } = null!;
}