using FilmFocusApi.Domain.Entities;

namespace FilmFocusApi.Application.Interfaces.ActorInterfaces
{
    public interface IGetAllActorsService
    {
        public Task<List<Actor>> GetAllActors();

    }
}
