using FilmFocusApi.Application.DTOs.Authentication;
using FilmFocusApi.Application.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmFocusApi.Infrastructure.Adapters.Input
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoogleAuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthenticateUserService _authenticationService;

        public GoogleAuthController(IConfiguration configuration, IAuthenticateUserService authenticationService)
        {
            _configuration = configuration;
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpGet("google-login")]
        public async Task<IActionResult> GoogleLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = "/api/GoogleAuth/google-callback" };
            return Challenge(properties,GoogleDefaults.AuthenticationScheme);
        }

        [AllowAnonymous]
        [HttpGet("google-callback")]
        public async Task<ActionResult> googleCallback()
        {
            AuthenticateResult authenticateResult = await HttpContext.AuthenticateAsync("GoogleCookies");

            if (!authenticateResult.Succeeded)
                return Unauthorized("Authentication failed.");

            AuthenticatedUserDTO user = await _authenticationService.AuthUser(authenticateResult);

            return Ok(new {message = "Authentication succcess", user= user});
        }

        [AllowAnonymous]
        [HttpGet("google-logout")]
        public async Task<IActionResult> googleLogout()
        {

            await HttpContext.SignOutAsync("GoogleCookies");

            return Ok("Usuario deslogeado correctamente.");
        }

    }
}
