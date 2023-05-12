using Google.Cloud.Firestore;

namespace Wishhh.Backend.Model.Users;

[FirestoreData]
public class Wishlist
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