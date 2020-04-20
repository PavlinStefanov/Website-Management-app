
namespace WebsiteManagement.Application.Abstractions.Queries
{
    public interface IHandleQuery<in TQuery, out TResult> where TQuery : IQuery<TResult>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        TResult Execute(TQuery query);
    }
}
