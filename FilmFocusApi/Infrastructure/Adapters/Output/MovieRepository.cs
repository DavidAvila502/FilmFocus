using FilmFocusApi.Application.OutputPorts;
using FilmFocusApi.Domain.Entities;
using FilmFocusApi.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace FilmFocusApi.Infrastructure.Adapters.Output
{
    public class MovieRepository:IMovieRepository
    {

        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllMovies()
        {
            List<Movie> movies = await _context.Movies.ToListAsync();

            return movies;
        }

        public async Task<Movie?> GetMovieById(int id)
        {
            Movie? movie = await _context.Movies.SingleOrDefaultAsync(x => x.Id == id);

            return movie;
        }

        public async Task<Movie> CreateMovie(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task UpdateMovie (int id, Movie movie)
        {
            Movie foundMovie = await _context.Movies.SingleOrDefaultAsync(m => m.Id == id);

            foundMovie!.Name = movie.Name;
            foundMovie!.Score = movie.Score;
            foundMovie!.ReleaseDate = movie.ReleaseDate;
            foundMovie!.Synopsis = movie.Synopsis;
            foundMovie!.ImageUrl = movie.ImageUrl;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovie(Movie movie)
        {
             _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

        }
    }
}
