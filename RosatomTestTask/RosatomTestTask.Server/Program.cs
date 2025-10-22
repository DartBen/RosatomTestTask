using Microsoft.EntityFrameworkCore;
using RosatomTestTask.Infrastructure;
using RosatomTestTask.Server.Extensions;
using Scalar.AspNetCore;

namespace RosatomTestTask.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.AddApplicationConfig();

            builder.Services.AddControllers();

            var app = builder.Build();

            // миграция для создания БД
            app.MigrateAppDb().GetAwaiter().GetResult();

            // для опенапи
            app.MapOpenApi();
            app.MapScalarApiReference();

            app.MapControllers();

            app.Run();
        }
    }
}
