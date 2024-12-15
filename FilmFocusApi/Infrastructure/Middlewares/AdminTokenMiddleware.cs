using System.Security.Claims;

namespace FilmFocusApi.Infrastructure.Middlewares
{
    public class AdminTokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public AdminTokenMiddleware(RequestDelegate next, IConfiguration configuration) 
        { 

            _next = next;
            _configuration = configuration;
        
        }

        public async Task InvokeAsync(HttpContext context) {

            string? authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();

            string? masterKey = _configuration["MasterToken:token"];

            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader == $"Bearer {masterKey}")
            {

                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name ,"MasterUser"),
                    new Claim(ClaimTypes.Role, "User"),
                    new Claim(ClaimTypes.Role, "Admin"),

                };

                var identity = new ClaimsIdentity(claims,"MasterToken");
                var principal = new ClaimsPrincipal(identity);

                context.User = principal;
            }

            await _next(context);
        }

    }
}
