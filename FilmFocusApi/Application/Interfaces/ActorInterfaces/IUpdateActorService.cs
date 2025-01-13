using FilmFocusApi.Application.DTOs.Actors;

namespace FilmFocusApi.Application.Interfaces.ActorInterfaces
{
    public interface IUpdateActorService
    {
        public Task UpdateActor(ActorUpdateDTO actorUpdateDto);

    }
}
