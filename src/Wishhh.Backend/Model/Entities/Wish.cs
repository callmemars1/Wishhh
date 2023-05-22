using Google.Cloud.Firestore;

namespace Wishhh.Backend.Model;

[FirestoreData]
public record Wish
{
    [FirestoreDocumentId]
    public string Id { get; set; }

    [FirestoreProperty("name")]
    public string Name { get; set; } = null!;
    
    [FirestoreProperty("price")]
    public double Price { get; set; }
    
    [FirestoreProperty("description")]
    public string? Description { get; set; }
    
    [FirestoreProperty("presenter_id")]
    public string? PresenterId { get; set; }
    
    [FirestoreProperty("image_path")]
    public string? ImagePath { get; set; } = null!;
}