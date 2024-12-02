using FilmFocusApi.Application.DTOs.Movies;
using FilmFocusApi.Application.InputPorts;
using FilmFocusApi.Application.Interfaces.MovieInterfaces;
using FilmFocusApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FilmFocusApi.Infrastructure.Adapters.Input
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase , IMoviePort
    {
        private readonly ICreateMovieService _createMovieService;

        public MovieController(ICreateMovieService createMovieService) { 
            
            _createMovieService = createMovieService;
            
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetAllMovies()
        {
            throw new NotImplementedException("Unimplemented enpoint");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovieById([FromRoute]int id)
        {
            throw new NotImplementedException("Unimplemented endpoint");
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> CreateMovie([FromForm]MovieInsertDTO movieInsertDTO)
        {
            try
            {
                Movie newMovie = await _createMovieService.CreateMovie(movieInsertDTO);

                return Ok(newMovie);

            }
            catch (KeyNotFoundException ex) 
            {
                return BadRequest(ex.Message);  
            
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new {message = ex.Message}); 
            }

           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie([FromRoute] int id,[FromBody] MovieUpdateDTO movieInsertDTO)
        {
            throw new NotImplementedException("Unimplemented endpoint");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie([FromRoute] int Id)
        {
            throw new NotImplementedException("Unimplented endpoint");
        }

    }
}
