using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebsiteManagement.Domain.Entities;

namespace WebsiteManagement.Persistence.Configurations
{
	public class WebsiteConfiguration : IEntityTypeConfiguration<Website>
	{
		public void Configure(EntityTypeBuilder<Website> builder)
		{
			builder.ToTable("Website");
			builder.HasKey(x => x.WebsiteId);
			builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
			builder.Property(x => x.Url).HasMaxLength(50).IsRequired();
			builder.Property(x => x.DateCreated).IsRequired();
			builder.Property<bool>("IsDeleted");
			builder.HasQueryFilter(x => EF.Property<bool>(x, "IsDeleted") == false);
			builder.HasOne(x => x.SiteCategory)
				.WithMany(x => x.Websites)
				.HasForeignKey(x => x.SiteCategoryId);
		}
	}
}
