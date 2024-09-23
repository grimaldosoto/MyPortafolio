using Catalog.Infrastructure.Persistences.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Extensions
{
    public  static class DataExtension
    {
        public static async Task MigrateDbAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<MyPortaLiveContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
