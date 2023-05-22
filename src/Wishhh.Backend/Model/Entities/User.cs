using Google.Cloud.Firestore;

namespace Wishhh.Backend.Model;

[FirestoreData]
public record User
{
    [FirestoreDocumentId]
    public string Id { get; init; }

    [FirestoreProperty("username")]
    public string Username { get; init; } = null!;

    [FirestoreProperty("password_hash")]
    public string PasswordHash { get; init; } = null!;
    
    [FirestoreProperty("password_salt")]
    public string PasswordSalt { get; init; } = null!;

    [FirestoreProperty("display_name")]
    public string DisplayName { get; init; } = null!;

    [FirestoreProperty("wishlists")] 
    public IEnumerable<Wishlist> Wishlists { get; init; }  = Array.Empty<Wishlist>();
    
    [FirestoreProperty("image_path")]
    public string? ImagePath { get; init; } = null!;
}