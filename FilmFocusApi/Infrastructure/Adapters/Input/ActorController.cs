using FilmFocusApi.Application.DTOs.Actors;
using FilmFocusApi.Application.InputPorts;
using FilmFocusApi.Application.Interfaces.ActorInterfaces;
using FilmFocusApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FilmFocusApi.Infrastructure.Adapters.Input
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase,IActorPort
    {
        private readonly IGetAllActorsService _getAllActorsService;
        private readonly IGetActorByIdService _getActorByIdService;
        private readonly ICreateActorService _createActorService;
        private readonly IUpdateActorService _updateActorService;
        private readonly IDeleteActorService _deleteActorService;

        public ActorController(
            IGetAllActorsService getAllActorsService,
            IGetActorByIdService getActorByIdService,
            ICreateActorService createActorService,
            IUpdateActorService updateActorService,
            IDeleteActorService deleteActorService
            )
        {
            _getAllActorsService = getAllActorsService;
            _getActorByIdService = getActorByIdService;
            _createActorService = createActorService;
            _updateActorService = updateActorService;
            _deleteActorService = deleteActorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Actor>>> GetAllActors()
        {
            try
            {
                List<Actor> actors = await _getAllActorsService.GetAllActors();

                return Ok(actors);
            }
            catch (ApplicationException ex) {

                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Actor>> GetActorById([FromRoute] int id)
        {
            try
            {
                Actor? actorFound = await _getActorByIdService.GetActorById(id);

                return Ok(actorFound);

            }catch(KeyNotFoundException ex){

                return NotFound(ex.Message);
            }
            catch (ApplicationException ex) {
                return StatusCode(500, new { message = ex.Message });

            }
        }

        [HttpPost]
        public async  Task<ActionResult<Actor>> CreateActor([FromForm] ActorInsertDTO actorInsertDto) 
        {
            try
            {
                Actor actorCreated = await _createActorService.CreateActor( actorInsertDto);
                return Ok(actorCreated);
            }
            catch ( ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message});
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateActor([FromBody] ActorUpdateDTO actorUpdateDTO)
        {
            try
            {
                await _updateActorService.UpdateActor( actorUpdateDTO);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteActor(int id)
        {
            try
            {
                await _deleteActorService.DeleteActor(id);
                return Ok();

            }catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
