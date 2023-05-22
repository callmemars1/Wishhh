using Google.Cloud.Firestore;

namespace Wishhh.Backend.Model;

[FirestoreData]
public record Wishlist
{
    [FirestoreDocumentId]
    public string Id { get; set; }

    [FirestoreProperty("name")]
    public string Name { get; set; } = null!;

    [FirestoreProperty("wishes")]
    public IEnumerable<Wish> Wishes { get; set; } = Array.Empty<Wish>();
    
    [FirestoreProperty("private")]
    public bool Private { get; set; }
    
    [FirestoreProperty("image_path")]    
    public string? ImagePath { get; set; } = null!;
}