using Microsoft.EntityFrameworkCore;
using RosatomTestTask.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosatomTestTask.Infrastructure
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(this RosatomTestTaskDbContext context)
        {
            // Защита: не сидим, если уже есть хоть один Master
            if (await context.Masters.AnyAsync())
                return;

            var random = new Random();
            var masters = new List<MasterEntity>();

            var productNames = new[]
            {
            "Сервер", "Лицензия", "Монитор", "Клавиатура", "Мышь",
            "Программное обеспечение", "Обучение", "Консультация",
            "Доставка", "Гарантийное обслуживание"
            };

            var notes = new[]
            {
            "Тестовый документ", "Демонстрационная накладная", "Сид-запись",
            "Пример для API", "Начальные данные"        
            };

            var baseDate = new DateTime(DateTime.UtcNow.Year, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            for (int i = 1; i <= 5; i++)
            {
                var detailCount = random.Next(1, 4); // 1–3 детали
                var details = new List<DetailEntity>();

                decimal totalAmount = 0;

                for (int j = 0; j < detailCount; j++)
                {
                    var productName = productNames[random.Next(productNames.Length)];
                    var amount = Math.Round((decimal)(random.Next(500, 5000) + random.NextDouble()), 2);
                    totalAmount += amount;

                    details.Add(new DetailEntity
                    {
                        Name = productName,
                        Amount = amount
                    });
                }

                var master = new MasterEntity
                {
                    Number = $"DOC-SEED-{i:D3}",
                    Date = baseDate.AddDays(random.Next(0, 365)),
                    Amount = totalAmount,
                    Note = notes[random.Next(notes.Length)],
                    Details = details
                };

                masters.Add(master);
            }

            await context.AddRangeAsync(masters);
            await context.SaveChangesAsync();
        }
    }
}
