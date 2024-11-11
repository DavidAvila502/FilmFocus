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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("users").Property(u => u.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(u => u.JoinDate).ValueGeneratedOnAdd();


        }
    }
}
