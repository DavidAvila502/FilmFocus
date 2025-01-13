using FilmFocusApi.Application.Interfaces.ActorInterfaces;
using FilmFocusApi.Domain.Entities;
using FilmFocusApi.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace FilmFocusApi.Application.Services.ActorServices
{
    public class GetAllActorsService:IGetAllActorsService
    {


        public readonly ApplicationDbContext _context;

        public GetAllActorsService( ApplicationDbContext context) { 
            _context = context;
        }

        public async Task<List<Actor>> GetAllActors()
        {
            try
            {
                List<Actor> actors = await _context.Actors.ToListAsync();

                return actors;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error trying to get all the actors.");
            }
        }


    }
}
