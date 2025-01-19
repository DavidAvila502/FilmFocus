using FilmFocusApi.Application.DTOs.Actors;
using FilmFocusApi.Application.Interfaces.ActorInterfaces;
using FilmFocusApi.Application.OutputPorts;
using FilmFocusApi.Domain.Entities;

namespace FilmFocusApi.Application.Services.ActorServices
{
    public class UpdateActorService:IUpdateActorService
    {

        private readonly IActorRepository _repository;
        
        public UpdateActorService(IActorRepository repository)
        {
            _repository = repository;
        }

        public async Task UpdateActor(ActorUpdateDTO actorUpdateDto)
        {
            Actor? actor = await _repository.GetActorById(actorUpdateDto.Id);

            if (actor == null)
            {
                throw new KeyNotFoundException("The actor to update doesn't exist.");    
            }

            try
            {
               actor.Name = actorUpdateDto.Name;
               await _repository.UpdateActor(actor);
            }
            catch (Exception ex) {

                throw new ApplicationException("Something went wrong trying to update the actor.");
            
            }
        }
    }
}
