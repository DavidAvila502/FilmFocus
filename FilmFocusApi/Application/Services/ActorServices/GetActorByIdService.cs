using FilmFocusApi.Application.Interfaces.ActorInterfaces;
using FilmFocusApi.Application.OutputPorts;
using FilmFocusApi.Domain.Entities;

namespace FilmFocusApi.Application.Services.ActorServices
{
    public class GetActorByIdService : IGetActorByIdService
    {

        public readonly IActorRepository _repository;

        public GetActorByIdService(IActorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Actor?> GetActorById(int id)
        {
            try
            {
                Actor? actor = await _repository.GetActorById(id);

                if (actor == null)
                {
                    throw new KeyNotFoundException("The requested actor was not found.");
                }

                return actor;
            }
            catch (Exception ex) {

                throw new ApplicationException("Something was wrong trying to get the requested actor.");

            }
        }
    } 

}
