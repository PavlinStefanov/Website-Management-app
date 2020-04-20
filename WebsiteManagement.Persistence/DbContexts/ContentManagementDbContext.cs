using WebsiteManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading;
using WebsiteManagement.Application.Abstractions;
using System.Threading.Tasks;
using WebsiteManagement.Persistence.Configurations;

namespace WebsiteManagement.Persistence.DbContexts
{
    public class ContentManagementDbContext : DbContext, IContentManagementDbContext
    {
        #region Entity Sets
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<Website> Websites { get; set; }
        public DbSet<SiteCategory> SiteCategories { get; set; }
        #endregion

        public ContentManagementDbContext(DbContextOptions<ContentManagementDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MediaTypeConfiguration());
            builder.ApplyConfiguration(new WebsiteConfiguration());
            builder.ApplyConfiguration(new SiteCategoryConfiguration());
            base.OnModelCreating(builder);
        }

        public void Commit()
        {
            OnBeforeSaving();
            base.SaveChanges();
        }

        public async Task<int> CommitAync(CancellationToken cancellationToken)
        {
            OnBeforeSaving();
            int result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        private void OnBeforeSaving()
        {
            foreach (var entity in ChangeTracker.Entries<Website>())
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.CurrentValues["IsDeleted"] = false;
                        break;
                    case EntityState.Deleted:
                        entity.State = EntityState.Modified;
                        entity.CurrentValues["IsDeleted"] = true;
                        break;
                }
            }
        }
    }
}
