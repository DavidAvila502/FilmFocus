using FilmFocusApi.Application.DTOs.Movies;
using FilmFocusApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FilmFocusApi.Application.InputPorts
{
    public interface IMoviePort
    {
        public Task<ActionResult<List<Movie>>> GetAllMovies();

        public Task<ActionResult<Movie>> GetMovieById(int id);

        public Task<ActionResult<Movie>> CreateMovie(MovieInsertDTO movieInsert);
     
        public Task<IActionResult> UpdateMovie(int id, MovieUpdateDTO movieUpdate);

        public Task<IActionResult> DeleteMovie(int Id);
    }
}
