using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using EM = WebsiteManagement.Domain.Entities;

namespace WebsiteManagement.Application.Abstractions
{
    public interface IContentManagementDbContext : IContext
    {
        #region
        DbSet<EM.Website> Websites { get; set; }
        DbSet<EM.MediaType> MediaTypes { get; set; }
        DbSet<EM.SiteCategory> SiteCategories { get; set; }
        #endregion

        void Commit();
        Task<int> CommitAync(CancellationToken cancellationToken);
        DatabaseFacade Database { get; }
    }
}
