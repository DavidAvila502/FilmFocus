using FilmFocusApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmFocusApi.Infrastructure.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users").Property(u => u.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(u => u.JoinDate).ValueGeneratedOnAdd();

            modelBuilder.Entity<Movie>().ToTable("Movies").Property(m => m.Id).ValueGeneratedOnAdd();

        }
    }
}
