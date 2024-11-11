using Microsoft.EntityFrameworkCore;

namespace FilmFocusApi.Infrastructure.Database
{
    public static class ApplicationDbContextExtension
    {

        public static IServiceCollection AddDbContextService(this IServiceCollection Service, WebApplicationBuilder builder)
        {
            Service.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            return Service;
        }

    }
}
