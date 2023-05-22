namespace Wishhh.Backend.Infrastructure;

public static class ImageHelper
{
    public static string GetUserImagePath(string userId, string imageId) => $"users/{userId}/{imageId}";
}