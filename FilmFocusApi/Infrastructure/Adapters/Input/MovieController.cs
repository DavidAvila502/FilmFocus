using FilmFocusApi.Application.DTOs.Movies;
using FilmFocusApi.Application.InputPorts;
using FilmFocusApi.Application.Interfaces.MovieInterfaces;
using FilmFocusApi.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmFocusApi.Infrastructure.Adapters.Input
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase , IMoviePort
    {
        private readonly ICreateMovieService _createMovieService;
        private readonly IUpdateMovieService _updateMovieService;
        private readonly IGetAllMoviesService _getAllMoviesService;
        private readonly IGetMovieByIdService _getMovieByIdService;
        private readonly IDeleteMovieService _deleteMovieByIdService;

        public MovieController(
            ICreateMovieService createMovieService,
            IUpdateMovieService updateMovieService,
            IGetAllMoviesService getAllMoviesService,
            IGetMovieByIdService getMovieByIdService,
            IDeleteMovieService deleteMovieService
            )
        { 
            _createMovieService = createMovieService;
            _updateMovieService = updateMovieService;
            _getAllMoviesService = getAllMoviesService;
            _getMovieByIdService = getMovieByIdService;
            _deleteMovieByIdService = deleteMovieService;
            
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetAllMovies()
        {
            try
            {
                List<Movie> movies = await _getAllMoviesService.GetAllMovies();

                return Ok(movies);

            }catch(ApplicationException ex)
            {
                return StatusCode(500,new {message= ex.Message});
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovieById([FromRoute]int id)
        {
            try
            {
                Movie? movie = await _getMovieByIdService.GetMovieById(id);

                return Ok(movie);

            }catch(Exception ex)
            {
                return StatusCode(500, new {message = ex.Message});
            }
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie([FromRoute] int id,[FromBody] MovieUpdateDTO movieUpdateDTO)
        {
            try
            {
                await _updateMovieService.UpdateMovie(id, movieUpdateDTO);

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);

            }
            catch (ApplicationException ex) {

                return StatusCode(500, new {message = ex.Message});
            }

        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie([FromRoute] int Id)
        {
            try
            {
                await _deleteMovieByIdService.DeleteMovie(Id);

                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new{ message = ex.Message});
            }
        }

    }
}
