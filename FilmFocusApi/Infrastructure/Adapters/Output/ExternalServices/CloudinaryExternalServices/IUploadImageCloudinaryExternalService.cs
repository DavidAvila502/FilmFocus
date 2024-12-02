namespace FilmFocusApi.Infrastructure.Adapters.Output.ExternalServices.CloudinaryExternalServices
{
    public interface IUploadImageCloudinaryExternalService
    {

        public Task<string> UploadImageAsync(IFormFile file);
    }
}
