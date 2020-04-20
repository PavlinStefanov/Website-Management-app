using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebsiteManagement.Domain.Entities;

namespace WebsiteManagement.Persistence.Configurations
{
    public class MediaTypeConfiguration : IEntityTypeConfiguration<MediaType>
    {
        public void Configure(EntityTypeBuilder<MediaType> builder)
        {
            builder.ToTable("MediaType");
            builder.HasKey(x => x.MediaTypeId);
            builder.Property(x => x.Name).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Extention).HasMaxLength(10).IsRequired();
            builder.Property(x => x.StoredLocation).HasMaxLength(200).IsRequired(required: false);
            builder.HasOne(x => x.Website).WithMany(x => x.MediaTypes).HasForeignKey(x => x.WebsiteId);
        }
    }
}
