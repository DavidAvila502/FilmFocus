using FilmFocusApi.Domain.Entities;

namespace FilmFocusApi.Application.Interfaces.MovieInterfaces
{
    public interface IGetAllMoviesService
    {
        public Task<List<Movie>> GetAllMovies();
    }
}
