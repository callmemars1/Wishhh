namespace Wishhh.Backend.Model.Images;

public interface IImageRepository
{
    public Task UploadImageAsync(IFormFile file, string path, Size? desiredSize = null!);

    public Task<Uri> GetImageUriAsync(string path);

    public Task DeleteImageAsync(string path);
}