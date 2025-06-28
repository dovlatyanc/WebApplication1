using Microsoft.EntityFrameworkCore;
using MovieApi.Domain;

namespace MovieApi.Repositories
{
    public class AppDbContext : DbContext
    {
     
        public AppDbContext()
        {
        }

        // Конструктор с опциями (для ASP.NET Core)
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Film> Films { get; set; }
        public DbSet<Session> Sessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Film>()
                .HasMany(f => f.Sessions)
                .WithOne(s => s.Film)
                .HasForeignKey(s => s.FilmId);
        }
    }
}