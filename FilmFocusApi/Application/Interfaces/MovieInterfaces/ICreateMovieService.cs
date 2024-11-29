using FilmFocusApi.Application.DTOs.Movies;
using FilmFocusApi.Domain.Entities;
namespace FilmFocusApi.Application.Interfaces.MovieInterfaces
{
    public interface ICreateMovieService
    {
        public Task<Movie> CreateMovie(MovieInsertDTO movieInsert);
    }
}
