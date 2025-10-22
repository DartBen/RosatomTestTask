using Microsoft.EntityFrameworkCore;
using Npgsql;
using RosatomTestTask.Infrastructure;
using RosatomTestTask.Infrastructure.UOW;

namespace RosatomTestTask.Server.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationConfig(this IHostApplicationBuilder builder)
        {
            builder.AddDatabase();

            builder.AddApplicationServices();

            builder.Services.AddControllers();
            builder.AddOpenApi();
        }
        public static void AddDatabase(this IHostApplicationBuilder builder)
        {
            var connectionString = Environment.GetEnvironmentVariable("DBConnectionString");

            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
            //dataSourceBuilder.EnableDynamicJson();

            var dataSource = dataSourceBuilder.Build();

            builder.Services.AddDbContext<RosatomTestTaskDbContext>(options =>
            {
                options.UseNpgsql(dataSource);
            });
        }

        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUnitOfWorks, UnitOfWorks>();
        }

        public static void AddOpenApi(this IHostApplicationBuilder builder)
        {
            builder.Services.AddOpenApi();
        }
    }
}
