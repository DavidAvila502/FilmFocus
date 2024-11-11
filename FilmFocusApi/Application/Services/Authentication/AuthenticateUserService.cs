using FilmFocusApi.Application.DTOs.Authentication;
using FilmFocusApi.Application.Interfaces;
using FilmFocusApi.Domain.Entities;
using FilmFocusApi.Infrastructure.Database;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FilmFocusApi.Application.Services.Authentication
{
    public class AuthenticateUserService:IAuthenticateUserService
    {

        private readonly IGenerateJwtTokenService _generateJwtTokenService;
        private readonly ApplicationDbContext _context;

        public AuthenticateUserService(IGenerateJwtTokenService generateJwtTokenService, ApplicationDbContext context)
        {
            _generateJwtTokenService = generateJwtTokenService;
            _context = context;
        }
        public async Task<AuthenticatedUserDTO> AuthUser(AuthenticateResult authenticateResult)
        {
            var claims = authenticateResult.Principal?.Claims;

            var googleId = claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var email = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var name = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var profilePicture = claims?.FirstOrDefault(c => c.Type == "picture")?.Value;

            string userJwtToken = _generateJwtTokenService.GenerateJwtToken(googleId, email, name);

            User? foundUser = await _context.Users.FirstOrDefaultAsync(u => u.GoogleId == googleId);

            if (foundUser != null) {
                return new AuthenticatedUserDTO() { Username = foundUser.Name, Email = foundUser.Email, JwtToken = userJwtToken };
            }

            try
            {
                User newUser = new User() { Name=name,Email=email,GoogleId=googleId,ProfileImageUrl=profilePicture};

                await _context.Users.AddAsync(newUser);

                await _context.SaveChangesAsync();

                return new AuthenticatedUserDTO() { Username = newUser.Name, Email = newUser.Email, JwtToken = userJwtToken };
            }
            catch (Exception ex) {
                throw new ApplicationException("Error trying to add the user.");
            }

 

        }


    }
}
