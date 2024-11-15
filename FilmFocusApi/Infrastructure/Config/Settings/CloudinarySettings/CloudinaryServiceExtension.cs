using CloudinaryDotNet;

using Microsoft.Extensions.Options;

namespace FilmFocusApi.Infrastructure.Config.Settings.CloudinarySettings
{
    public static class CloudinaryServiceExtension
    {
        public static IServiceCollection AddCloudinaryService(this IServiceCollection Service, WebApplicationBuilder builder)
        {
            builder.Services.Configure<CloudinarySettingsModel>(builder.Configuration.GetSection("CloudinarySettings"));
        
        return  builder.Services.AddSingleton(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<CloudinarySettingsModel>>().Value;

                return new Cloudinary(new Account(settings.CloudName, settings.ApiKey, settings.ApiSecret));

            });


        }
    }
}
