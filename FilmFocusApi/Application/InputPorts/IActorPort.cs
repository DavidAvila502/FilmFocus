using FilmFocusApi.Application.DTOs.Actors;
using FilmFocusApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FilmFocusApi.Application.InputPorts
{
    public interface IActorPort
    {
        public Task<ActionResult<List<Actor>>> GetAllActors();

        public Task<ActionResult<Actor>> GetActorById(int id);

        public Task<ActionResult<Actor>> CreateActor(ActorInsertDTO actorInsertDTO);

        public Task<ActionResult> UpdateActor(ActorUpdateDTO actorUpdateDTO);

        public Task<ActionResult> DeleteActor(int id);
    }
}
