using FilmFocusApi.Application.Interfaces.ActorInterfaces;
using FilmFocusApi.Application.OutputPorts;
using FilmFocusApi.Domain.Entities;


namespace FilmFocusApi.Application.Services.ActorServices
{
    public class GetAllActorsService:IGetAllActorsService
    {
        public readonly IActorRepository _repository;

        public GetAllActorsService( IActorRepository repository) { 
            _repository = repository;
        }

        public async Task<List<Actor>> GetAllActors()
        {
            try
            {
                List<Actor> actors = await _repository.GetAllActors();

                return actors;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error trying to get all the actors.");
            }
        }
    }
}
