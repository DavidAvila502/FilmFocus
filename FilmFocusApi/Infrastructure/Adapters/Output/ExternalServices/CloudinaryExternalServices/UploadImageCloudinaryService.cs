using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace FilmFocusApi.Infrastructure.Adapters.Output.ExternalServices.CloudinaryExternalServices
{
    public class UploadImageCloudinaryService:IUploadImageCloudinaryExternalService
    {

        private readonly Cloudinary _cloudinary;

        public UploadImageCloudinaryService(Cloudinary cloudinary) { 
            
            _cloudinary = cloudinary;
        
        }

        public async Task<string> UploadImageAsync(IFormFile file)
        {
            await using var stream = file.OpenReadStream();

            ImageUploadParams uploadParams = new ImageUploadParams 
            { 
                File = new FileDescription(file.FileName,stream),
            
            };


            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            return uploadResult.SecureUrl.AbsoluteUri;

        } 


    }
}
