using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;

namespace Wishhh.Backend.Model.Users;

public class FirebaseUserRepository : IUserRepository
{
    private readonly FirestoreDb _db;

    public FirebaseUserRepository(FirestoreClient client)
    {
        _db = FirestoreDb.Create("wishhh-martynov", client);
    }

    public async Task CreateUser()
    {
        await _db.Collection("users").AddAsync(
            new User
            {
                DisplayName = "Sergey Martynov",
                PasswordHash = "cringe hash",
                PasswordSalt = "Cringe Salt",
                Username = "smartynov",
                Wishlists = new []
                {
                    new Wishlist
                    {
                        Name = "Wishlist 1",
                        Private = false,
                        Wishes = new []
                        {
                            new Wish
                            {
                                Name = "Wish 228",
                                Description = "My wish",
                                Price = 228
                            }
                        }
                    }
                }
            }
        );
    }
}