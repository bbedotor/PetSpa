using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetSpa.API.Data.Entities;

namespace PetSpa.API.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Breed> Breeds { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<PetType> PetTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PetType>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Treatment>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Breed>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<DocumentType>().HasIndex(x => x.Description).IsUnique();
        }

    }
}
