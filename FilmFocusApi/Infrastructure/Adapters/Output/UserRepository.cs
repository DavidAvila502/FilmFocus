using FilmFocusApi.Application.OutputPorts;
using FilmFocusApi.Domain.Entities;
using FilmFocusApi.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace FilmFocusApi.Infrastructure.Adapters.Output
{
    public class UserRepository:IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) { 
            
            _context = context;
        }


        public async Task<User?> GetUserById(int id)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }

        public async Task<User?> GetUserByGoogleId(string googleId)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x=> x.GoogleId == googleId);

            return user;
        }

        public async Task RegisterUser(User user)
        {
            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();
        }
    }
}
