using FilmFocusApi.Domain.Entities;

namespace FilmFocusApi.Application.OutputPorts
{
    public interface IMovieRepository
    {

        public Task<List<Movie>> GetAllMovies();

        public Task<Movie?> GetMovieById(int id);

        public Task<Movie> CreateMovie(Movie movie);

        public Task UpdateMovie(int id ,Movie movie);

        public Task DeleteMovie(Movie movie);
    }
}
