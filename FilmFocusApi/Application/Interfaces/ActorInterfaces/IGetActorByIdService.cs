using FilmFocusApi.Domain.Entities;

namespace FilmFocusApi.Application.Interfaces.ActorInterfaces
{
    public interface IGetActorByIdService
    {
        public  Task<Actor?> GetActorById(int id);
    }
}
