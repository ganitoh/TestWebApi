using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebApi.Domain.Models;

namespace TestWebApi.Persistance.Cinfiguration
{
    internal class FriendShipsConfiguration : IEntityTypeConfiguration<FriendShip>
    {
        public void Configure(EntityTypeBuilder<FriendShip> builder)
        {
            builder.HasKey(f =>f.Id);

            builder
                .HasOne(f => f.UserFrom)
                .WithMany(u => u.FriendShips)
                .HasForeignKey(f => f.UserFromId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
