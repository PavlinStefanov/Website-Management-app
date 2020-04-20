using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebsiteManagement.Domain.Entities;

namespace WebsiteManagement.Persistence.Configurations
{
    public class SiteCategoryConfiguration : IEntityTypeConfiguration<SiteCategory>
    {
        public void Configure(EntityTypeBuilder<SiteCategory> builder)
        {
            builder.ToTable("SiteCategory");
            builder.HasKey(x => x.SiteCategoryId);
            builder.Property(x => x.Name).HasMaxLength(25).IsRequired();
        }
    }
}
