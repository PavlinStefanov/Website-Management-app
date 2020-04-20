using WebsiteManagement.Application.Abstractions;

namespace WebsiteManagement.Persistence.DbContexts
{
    public class DbContextFactory : IDbContextFactory<IContext>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public IContext CreateDbContext
        {
            get;
        }
    }
}
