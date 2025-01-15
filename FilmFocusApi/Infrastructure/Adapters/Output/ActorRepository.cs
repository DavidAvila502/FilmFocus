using FilmFocusApi.Application.OutputPorts;
using FilmFocusApi.Domain.Entities;
using FilmFocusApi.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace FilmFocusApi.Infrastructure.Adapters.Output
{
    public class ActorRepository:IActorRepository
    {

        public readonly ApplicationDbContext _context;


        public ActorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Actor>> GetAllActors()
        {
            List<Actor> actors = await _context.Actors.ToListAsync();
            return actors;
        }

        public async Task<Actor?> GetActorById(int Id)
        {
            Actor? actor = await _context.Actors.SingleOrDefaultAsync(a => a.Id == Id);

            return actor;
        }

        public async Task CreateActor(Actor actor) 
        { 
           _context.Actors.Add(actor);

            await _context.SaveChangesAsync();
        
        }
        public async Task UpdateActor(Actor actor)
        {
            _context.Actors.Update(actor);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteActor(Actor actor)
        {
            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
        }

    }
}
