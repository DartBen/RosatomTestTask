using Microsoft.EntityFrameworkCore;
using RosatomTestTask.Infrastructure;

namespace RosatomTestTask.Server.Extensions
{
    public static class AppCollectionExtensions
    {
        public static void MigrateAppDb(this WebApplication app)
        {
            // Применяем миграции при старте
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<RosatomTestTaskDbContext>();
                dbContext.Database.Migrate(); // ← создаёт таблицы на основе миграций
            }
        }
    }
}
