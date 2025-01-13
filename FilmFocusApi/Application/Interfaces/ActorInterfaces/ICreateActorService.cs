using FilmFocusApi.Application.DTOs.Actors;
using FilmFocusApi.Domain.Entities;

namespace FilmFocusApi.Application.Interfaces.ActorInterfaces
{
    public interface ICreateActorService
    {

        public Task<Actor> CreateActorService(ActorInsertDTO actorInsertDto);
    }
}
