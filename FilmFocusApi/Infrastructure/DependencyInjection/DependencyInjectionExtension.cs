using FilmFocusApi.Application.Interfaces;
using FilmFocusApi.Application.OutputPorts;
using FilmFocusApi.Application.Services.Authentication;
using FilmFocusApi.Infrastructure.Adapters.Output;

namespace FilmFocusApi.Infrastructure.DependencyInjection
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjectionServices(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddSingleton<IGenerateJwtTokenService, GenerateJwtTokenService>();
            services.AddTransient<IAuthenticateUserService, AuthenticateUserService>();

            return services;
        }

    }
}
