using FilmFocusApi.Application.DTOs.Movies;
using FilmFocusApi.Application.Interfaces.MovieInterfaces;
using FilmFocusApi.Application.OutputPorts;
using FilmFocusApi.Domain.Entities;

namespace FilmFocusApi.Application.Services.MovieServices
{
    public class CreateMovieService:ICreateMovieService
    {

        private readonly IMovieRepository _movieRepository;

        CreateMovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;

        }

        public async Task<Movie> CreateMovie(MovieInsertDTO movieInsertDTO)
        {


            throw new Exception("Unimplemented function");

        }

    }
}
