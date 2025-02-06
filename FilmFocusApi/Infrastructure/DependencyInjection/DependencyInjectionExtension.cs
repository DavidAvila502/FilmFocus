using FilmFocusApi.Application.Interfaces.ActorInterfaces;
using FilmFocusApi.Application.Interfaces.Authentication;
using FilmFocusApi.Application.Interfaces.MovieInterfaces;
using FilmFocusApi.Application.Interfaces.ReviewInterfaces;
using FilmFocusApi.Application.OutputPorts;
using FilmFocusApi.Application.Services.ActorServices;
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
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IActorRepository, ActorRepository>();

            //Services
            services.AddSingleton<IGenerateJwtTokenService, GenerateJwtTokenService>();
            services.AddScoped<IAuthenticateUserService, AuthenticateUserService>();

            services.AddScoped<ICreateMovieService, CreateMovieService>();
            services.AddScoped<IUpdateMovieService, UpdateMovieService>();
            services.AddScoped<IDeleteMovieService, DeleteMovieService>();
            services.AddScoped<IGetAllMoviesService, GetAllMoviesService>();
            services.AddScoped<IGetMovieByIdService, GetMovieByIdService>();

            services.AddScoped<ICreateReviewService, CreateReviewService>();
            services.AddScoped<IDeleteReviewService, DeleteReviewService>();
            services.AddScoped<IGetAllReviewsService, GetAllReviewsService>();
            services.AddScoped<IGetReviewByIdService, GetReviewByIdService>();

            services.AddScoped<IGetAllActorsService,GetAllActorsService>();
            services.AddScoped<IGetActorByIdService, GetActorByIdService>();
            services.AddScoped<ICreateActorService, CreateActorService>();
            services.AddScoped<IUpdateActorService, UpdateActorService>();
            services.AddScoped<IDeleteActorService, DeleteActorService>();


            //External services
            services.AddSingleton<IUploadImageCloudinaryExternalService, UploadImageCloudinaryService>();


            return services;
        }

    }
}
