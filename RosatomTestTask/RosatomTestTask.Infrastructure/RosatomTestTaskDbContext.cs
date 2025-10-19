using Microsoft.EntityFrameworkCore;
using RosatomTestTask.Infrastructure.Entities;

namespace RosatomTestTask.Infrastructure
{
    public class RosatomTestTaskDbContext : DbContext
    {
        public RosatomTestTaskDbContext(DbContextOptions<RosatomTestTaskDbContext> options) : base(options) { }

        public DbSet<MasterEntity> Masters { get; set; }
        public DbSet<DetailEntity> Details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MasterEntity>()
                .HasMany(m => m.Details)
                .WithOne(d => d.Master)
                .HasForeignKey(d => d.MasterId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MasterEntity>()
                .Property(m => m.Number)
                .IsRequired();

            // Уникальность номера документа
            modelBuilder.Entity<MasterEntity>()
                .HasIndex(m => m.Number)
                .IsUnique();

            modelBuilder.Entity<DetailEntity>()
                .Property(d => d.Name)
                .IsRequired();
        }
    }
}
