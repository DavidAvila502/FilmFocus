using FilmFocusApi.Domain.Entities;

namespace FilmFocusApi.Application.OutputPorts
{
    public interface IUserRepository
    {

        public Task<User?> GetUserById(int id);

        public Task<User?> GetUserByGoogleId(string googleId);

        public Task RegisterUser(User user);
    }
}
