using Microsoft.EntityFrameworkCore;
using TestWebApi.Persistance.Cinfiguration;
using TestWebApi.Domain.Models;

namespace TestWebApi.Persistance.Services.Repository.Implementation
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Picture> Pictures  { get; set; }
        public DbSet<FriendShip> FriendShips  { get; set; }

        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PictureConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new FriendShipsConfiguration());
        }
    }
}
