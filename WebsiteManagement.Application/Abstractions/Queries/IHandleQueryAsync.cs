
namespace WebsiteManagement.Application.Abstractions.Queries
{
    public interface IHandleQueryAsync<in TQuery, TResult> where TQuery : IQuery<TResult>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        TResult ExecuteAsync(TQuery query);
    }
}
