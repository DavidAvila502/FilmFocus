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

        public DbSet<Review> Reviews { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Users
            modelBuilder.Entity<User>().ToTable("Users").Property(u => u.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(u => u.JoinDate).ValueGeneratedOnAdd();
            //Movies
            modelBuilder.Entity<Movie>().ToTable("Movies").Property(m => m.Id).ValueGeneratedOnAdd();
            //Reviews 
            modelBuilder.Entity<Review>().ToTable("Reviews").Property(r => r.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Review>().Property(r => r.ReviewDate).ValueGeneratedOnAdd();



        }
    }
}
