using FilmFocusApi.Application.DTOs.Movies;
using FilmFocusApi.Application.Interfaces.MovieInterfaces;
using FilmFocusApi.Application.OutputPorts;
using FilmFocusApi.Domain.Entities;
using FilmFocusApi.Infrastructure.Adapters.Output;
using FilmFocusApi.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace FilmFocusApi.Application.Services.MovieServices
{
    public class UpdateMovieService:IUpdateMovieService
    {
        public readonly ApplicationDbContext _context;
        public readonly IMovieRepository _movieRepository;

        public UpdateMovieService(ApplicationDbContext context, IMovieRepository movieRepository)
        {
            _context = context;
            _movieRepository = movieRepository;
        }

        public async Task UpdateMovie(int id, MovieUpdateDTO movieUpdateDTO)
        {
            Movie? foundMovie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);

            if (foundMovie == null) {

                throw new ArgumentNullException("The movie was not found.");
            
            }

            Movie newUpdateMovie = new Movie() 
            {
              Id = id ,Name=movieUpdateDTO.Name,
              Score =movieUpdateDTO.Score,
              ReleaseDate = movieUpdateDTO.ReleaseDate,
              Synopsis = movieUpdateDTO.Synopsis,
            };

            try
            {
                await _movieRepository.UpdateMovie(id, newUpdateMovie);

            }
            catch (Exception ex) {

                throw new ApplicationException("Something was wrong trying to update the movie.");
            
            }
        }
    }
}
