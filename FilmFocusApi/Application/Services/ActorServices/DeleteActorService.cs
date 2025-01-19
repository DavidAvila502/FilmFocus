using FilmFocusApi.Application.Interfaces.ActorInterfaces;
using FilmFocusApi.Application.OutputPorts;
using FilmFocusApi.Domain.Entities;

namespace FilmFocusApi.Application.Services.ActorServices
{
    public class DeleteActorService:IDeleteActorService
    {
        public readonly IActorRepository _repository;


        public DeleteActorService(IActorRepository repository)
        {
            _repository = repository;
        }

        public async Task DeleteActor(int id)
        {
            Actor? actor = await _repository.GetActorById(id);

            if (actor == null) {
                throw new KeyNotFoundException("The requested actor was not found");
            }

            try
            {
                await _repository.DeleteActor(actor);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Something went wrong trying to delete the actor.");
            }

        }
    }
}
