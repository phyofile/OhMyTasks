using Microsoft.EntityFrameworkCore;
using TasksManagerMVC.Models;

namespace TasksManagerMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskItem> AspNetOhMyTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.ToTable("AspNetOhMyTasks");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.IsCompleted);
            });
        }
    }
}