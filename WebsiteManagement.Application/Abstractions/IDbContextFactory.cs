
namespace WebsiteManagement.Application.Abstractions
{
    public interface IDbContextFactory<out TContext> where TContext : IContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IContext CreateDbContext { get; }
    }
}
