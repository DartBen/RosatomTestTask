using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosatomTestTask.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RosatomTestTaskDbContext>
    {
        public RosatomTestTaskDbContext CreateDbContext(string[] args)
        {
            // Берём строку подключения из переменной окружения
            var connectionString = Environment.GetEnvironmentVariable("DBConnectionString")
                ?? throw new InvalidOperationException("DBConnectionString environment variable is not set.");

            var dataSource = new NpgsqlDataSourceBuilder(connectionString)
                .EnableDynamicJson()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<RosatomTestTaskDbContext>();
            optionsBuilder.UseNpgsql(dataSource);

            return new RosatomTestTaskDbContext(optionsBuilder.Options);
        }
    }
}
