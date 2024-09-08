using Catalog.API.Extensions;
using Catalog.Application.Extensions;
using Catalog.Infrastructure.Extensions;
using Catalog.Infrastructure.Persistences.Contexts;
using Microsoft.EntityFrameworkCore;
using WatchDog;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var Cors = "Cors";

// Add services to the container.
builder.Services.AddInjectionInfrastructure(configuration);
builder.Services.AddInjectionApplication(configuration);
builder.Services.AddAuthentication(configuration);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Cors,
        builder =>
        {
            builder.WithOrigins("*");
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseCors(Cors);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    await app.MigrateDbAsync();

}

app.UseWatchDogExceptionLogger();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseWatchDog(config =>
{
    config.WatchPageUsername = configuration.GetSection("WatchDog:Username").Value;
    config.WatchPagePassword = configuration.GetSection("WatchDog:Password").Value;
});

app.Run();

public partial class Program { }
