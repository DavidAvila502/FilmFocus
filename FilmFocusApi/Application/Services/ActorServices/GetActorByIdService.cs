using FilmFocusApi.Application.Interfaces.ActorInterfaces;
using FilmFocusApi.Domain.Entities;
using FilmFocusApi.Infrastructure.Database;

namespace FilmFocusApi.Application.Services.ActorServices
{
    public class GetActorByIdService : IGetActorByIdService
    {

        public readonly ApplicationDbContext _context;

        public GetActorByIdService(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<Actor> GetActorById(int id)
        {
            try
            {
                Actor? actor = await _context.Actors.FindAsync(id);

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
