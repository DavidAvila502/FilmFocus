using FilmFocusApi.Domain.Entities;

namespace FilmFocusApi.Application.Interfaces.MovieInterfaces
{
    public interface IGetMovieByIdService
    {
        public Task<Movie?> GetMovieById(int id);
    }
}
