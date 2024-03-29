
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWebApi.Domain.Models;

namespace TestWebApi.Persistance.Cinfiguration
{
    internal class PictureConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.RelativePath).IsRequired();
            builder
                .Property(p => p.Description)
                .IsRequired(false)
                .HasMaxLength(200);
        }
    }
}
