using FilmFocusApi.Application.Interfaces.Authentication;
using FilmFocusApi.Application.Interfaces.MovieInterfaces;
using FilmFocusApi.Application.OutputPorts;
using FilmFocusApi.Application.Services.Authentication;
using FilmFocusApi.Application.Services.MovieServices;
using FilmFocusApi.Infrastructure.Adapters.Output;

namespace FilmFocusApi.Infrastructure.DependencyInjection
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjectionServices(this IServiceCollection services)
        {
            //Repositories
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();

            //Services
            services.AddSingleton<IGenerateJwtTokenService, GenerateJwtTokenService>();
            services.AddTransient<IAuthenticateUserService, AuthenticateUserService>();
            services.AddSingleton<ICreateMovieService, CreateMovieService>();


            return services;
        }

    }
}
