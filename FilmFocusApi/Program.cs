using FilmFocusApi.Infrastructure.Config.Settings.Authentication;
using FilmFocusApi.Infrastructure.Config.Settings.CloudinarySettings;
using FilmFocusApi.Infrastructure.Database;
using FilmFocusApi.Infrastructure.DependencyInjection;
using FilmFocusApi.Infrastructure.Middlewares;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCustomAuthentication(builder);

builder.Services.AddDbContextService(builder);

builder.Services.AddCloudinaryService(builder);

builder.Services.AddDependencyInjectionServices();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<AdminTokenMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
