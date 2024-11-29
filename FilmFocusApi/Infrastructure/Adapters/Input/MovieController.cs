using FilmFocusApi.Application.DTOs.Movies;
using FilmFocusApi.Application.InputPorts;
using FilmFocusApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FilmFocusApi.Infrastructure.Adapters.Input
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase , IMoviePort
    {
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

            return Ok( new Movie { Id = 1, Name = movieInsertDTO.Name, ImageUrl= "www.helloWorld.com", ReleaseDate= movieInsertDTO.ReleaseDate, Score= movieInsertDTO.Score});

            

            //throw new NotImplementedException("Unimplemented endpoint");
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
