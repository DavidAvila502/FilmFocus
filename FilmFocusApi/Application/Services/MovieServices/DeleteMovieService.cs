using FilmFocusApi.Application.Interfaces.MovieInterfaces;
using FilmFocusApi.Domain.Entities;
using FilmFocusApi.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace FilmFocusApi.Application.Services.MovieServices
{
    public class DeleteMovieService:IDeleteMovieService
    {

        private readonly ApplicationDbContext _context;
        public DeleteMovieService(ApplicationDbContext context) {
            
            _context = context;
        
        }

        public async Task DeleteMovie(int id) 
        {
            
            Movie? foundMovie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);

            if (foundMovie == null)
            {
                throw new KeyNotFoundException("The movie was not found.");
            }

            try
            {
                 _context.Movies.Remove(foundMovie);  

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Something went wrong trying to delete the movie.");
            }
        
        }
    }
}
