namespace FilmFocusApi.Application.Interfaces
{
    public interface IGenerateJwtTokenService
    {
        public  string GenerateJwtToken(string googleId, string email, string name);
    }
}
