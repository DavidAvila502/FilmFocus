using FilmFocusApi.Application.Interfaces;
using FilmFocusApi.Application.Services.Authentication;

namespace FilmFocusApi.Infrastructure.DependencyInjection
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjectionServices(this IServiceCollection services)
        {
            services.AddSingleton<IGenerateJwtTokenService, GenerateJwtTokenService>();
            services.AddTransient<IAuthenticateUserService, AuthenticateUserService>();

            return services;
        }

    }
}
