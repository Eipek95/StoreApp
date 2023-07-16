using Microsoft.EntityFrameworkCore;
using Repositories;

namespace StoreApp.Infrastructe.Extensions
{
    public static class ApplicationExtensions
    {
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {
            RepositoryContext context = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RepositoryContext>();


            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();//bu methodla beraber update-database komutu yazmamıza gerek kalmadı
            }
        }

        public static void ConfigureLocalization(this WebApplication app)
        {
            app.UseRequestLocalization(options =>
            {
                options.AddSupportedCultures("tr-TR")
                .SetDefaultCulture("tr-TR");
            });
        }
    }
}
