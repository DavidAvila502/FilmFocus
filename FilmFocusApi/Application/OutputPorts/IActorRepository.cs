using FilmFocusApi.Domain.Entities;

namespace FilmFocusApi.Application.OutputPorts
{
    public interface IActorRepository
    {
        public Task<List<Actor>> GetAllActors();

        public Task<Actor?> GetActorById(int Id);

        public Task CreateActor(MoviesActors movieActor, Actor actor);

        public Task UpdateActor( Actor actor);

        public Task DeleteActor(Actor actor);
    }
}
