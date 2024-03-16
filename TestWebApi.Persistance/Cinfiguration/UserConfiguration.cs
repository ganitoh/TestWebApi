using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebApi.Domain.Models;

namespace TestWebApi.Persistance.Cinfiguration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Login).IsRequired();
            builder.Property(u => u.HashPassword).IsRequired();

            builder
                .HasMany(u=>u.Pictures)
                .WithOne(p=>p.User)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
