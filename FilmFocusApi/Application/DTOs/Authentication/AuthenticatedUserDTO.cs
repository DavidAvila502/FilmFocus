namespace FilmFocusApi.Application.DTOs.Authentication
{
    public class AuthenticatedUserDTO
    {
        public required string JwtToken { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
