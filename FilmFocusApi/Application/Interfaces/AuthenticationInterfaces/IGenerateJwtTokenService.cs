namespace FilmFocusApi.Application.Interfaces.Authentication
{
    public interface IGenerateJwtTokenService
    {
        public string GenerateJwtToken(string googleId, string email, string name);
    }
}
