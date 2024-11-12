using FilmFocusApi.Application.DTOs.Authentication;
using FilmFocusApi.Application.Interfaces;
using FilmFocusApi.Application.OutputPorts;
using FilmFocusApi.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace FilmFocusApi.Application.Services.Authentication
{
    public class AuthenticateUserService:IAuthenticateUserService
    {

        private readonly IGenerateJwtTokenService _generateJwtTokenService;
        private readonly IUserRepository _userRepository;

        public AuthenticateUserService(IGenerateJwtTokenService generateJwtTokenService, IUserRepository userRepository)
        {
            _generateJwtTokenService = generateJwtTokenService;
            _userRepository = userRepository;
        }
        public async Task<AuthenticatedUserDTO> AuthUser(AuthenticateResult authenticateResult)
        {
            var claims = authenticateResult.Principal?.Claims;
            // Get user properties
            var googleId = claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var email = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var name = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var profilePicture = claims?.FirstOrDefault(c => c.Type == "picture")?.Value;
           
            string userJwtToken = _generateJwtTokenService.GenerateJwtToken(googleId, email, name);
           
            //Find user by Google Id
            User? foundUser = await _userRepository.GetUserByGoogleId(googleId);

            if (foundUser != null) {
                return new AuthenticatedUserDTO() { Username = foundUser.Name, Email = foundUser.Email, JwtToken = userJwtToken };
            }

            try
            {   
                //Create new user Object
                User newUser = new User() { Name=name,Email=email,GoogleId=googleId,ProfileImageUrl=profilePicture};
                //Register user in to DB
                await _userRepository.RegisterUser(newUser);
                //Return DTO
                return new AuthenticatedUserDTO() { Username = newUser.Name, Email = newUser.Email, JwtToken = userJwtToken };
            }
            catch (Exception ex) {
                throw new ApplicationException("Error trying to add the user.");
            }

 

        }


    }
}
