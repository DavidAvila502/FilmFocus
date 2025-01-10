using FilmFocusApi.Application.Interfaces.Authentication;
using FilmFocusApi.Application.Interfaces.MovieInterfaces;
using FilmFocusApi.Application.Interfaces.ReviewInterfaces;
using FilmFocusApi.Application.OutputPorts;
using FilmFocusApi.Application.Services.Authentication;
using FilmFocusApi.Application.Services.MovieServices;
using FilmFocusApi.Application.Services.ReviewServices;
using FilmFocusApi.Infrastructure.Adapters.Output;
using FilmFocusApi.Infrastructure.Adapters.Output.ExternalServices.CloudinaryExternalServices;

namespace FilmFocusApi.Infrastructure.DependencyInjection
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjectionServices(this IServiceCollection services)
        {
            //Repositories
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();

            //Services
            services.AddSingleton<IGenerateJwtTokenService, GenerateJwtTokenService>();
            services.AddTransient<IAuthenticateUserService, AuthenticateUserService>();

            services.AddTransient<ICreateMovieService, CreateMovieService>();
            services.AddTransient<IUpdateMovieService, UpdateMovieService>();
            services.AddTransient<IDeleteMovieService, DeleteMovieService>();
            services.AddTransient<IGetAllMoviesService, GetAllMoviesService>();
            services.AddTransient<IGetMovieByIdService, GetMovieByIdService>();

            services.AddTransient<ICreateReviewService, CreateReviewService>();
            services.AddTransient<IDeleteReviewService, DeleteReviewService>();
            services.AddTransient<IGetAllReviewsService, GetAllReviewsService>();
            services.AddTransient<IGetReviewByIdService, GetReviewByIdService>();

            //External services
            services.AddSingleton<IUploadImageCloudinaryExternalService, UploadImageCloudinaryService>();


            return services;
        }

    }
}
