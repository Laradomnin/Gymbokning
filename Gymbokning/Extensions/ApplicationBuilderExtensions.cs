using Gymbokning.Data;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Gymbokning.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task <IApplicationBuilder> SeedDataAsync (this IApplicationBuilder app)
        {
        using (var scope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var db = serviceProvider.GetRequiredService<ApplicationDbContext>();

                //db.Database.EnsureDeleted();
                //db.Database.Migrate();
                var config = serviceProvider.GetRequiredService<Configuration>();
                var adminPW = config ["AdminPW"];
                try
                {
                    await SeedData.InitAsync(db, serviceProvider,adminPW);

                }
                catch (Exception e)
                {
                    throw;
                }
            }
        return app;
        }
    }
}
