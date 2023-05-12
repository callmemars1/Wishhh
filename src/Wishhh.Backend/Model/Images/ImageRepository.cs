using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.Extensions.Options;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Processing.Processors.Transforms;

namespace Wishhh.Backend.Model.Images;

public class FirebaseStorageImageRepository : IImageRepository
{
    private readonly GoogleStorageOptions _options;
    private readonly ILogger<FirebaseStorageImageRepository> _logger;
    private readonly StorageClient _client;

    public FirebaseStorageImageRepository(
        ILogger<FirebaseStorageImageRepository> logger,
        IOptions<GoogleStorageOptions> options,
        StorageClient client)
    {
        _options = options.Value;
        _logger = logger;
        _client = client;
    }

    public async Task UploadImageAsync(IFormFile file, string path, Size? desiredSize = null!)
    {
        using var outStream = new MemoryStream();
        using var image = await Image.LoadAsync(file.OpenReadStream());

        if (desiredSize.HasValue)
            image.Mutate(x =>
                x.Resize(desiredSize.Value, LanczosResampler.Lanczos3, true));

        await image.SaveAsync(outStream, image.DetectEncoder(file.FileName));

        await _client.UploadObjectAsync(
            _options.BucketName,
            path,
            file.ContentType,
            outStream);
    }

    public async Task DeleteImageAsync(string path)
    {
        await _client.DeleteObjectAsync(_options.BucketName, path);
    }

    public async Task<Uri> GetImageUriAsync(string path)
    {
        var signer = UrlSigner.FromCredential(GoogleCredential.FromJson(_options.CredentialsJson));
        var url = await signer.SignAsync(_options.BucketName, path, TimeSpan.FromMinutes(1));
        return new Uri(url);
    }
}