using FilmFocusApi.Application.DTOs.Authentication;
using FilmFocusApi.Application.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace FilmFocusApi.Application.Services.Authentication
{
    public class AuthenticateUserService:IAuthenticateUserService
    {

        private readonly IGenerateJwtTokenService _generateJwtTokenService;

        public AuthenticateUserService(IGenerateJwtTokenService generateJwtTokenService)
        {
            _generateJwtTokenService = generateJwtTokenService;
        }
        public async Task<AuthenticatedUserDTO> AuthUser(AuthenticateResult authenticateResult)
        {
            var claims = authenticateResult.Principal?.Claims;

            var googleId = claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var email = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var name = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var profilePicture = claims?.FirstOrDefault(c => c.Type == "picture")?.Value;

            string userJwtToken = _generateJwtTokenService.GenerateJwtToken(googleId, email, name);


            return new AuthenticatedUserDTO() { Username= name, Email= email, JwtToken= userJwtToken };

        }


    }
}
