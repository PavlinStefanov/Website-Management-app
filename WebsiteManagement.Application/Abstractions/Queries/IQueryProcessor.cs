using System.Threading.Tasks;

namespace WebsiteManagement.Application.Abstractions.Queries
{
    public interface IQueryProcessor
    {
        TResult Process<TResult>(IQuery<TResult> query);
        Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query);
    }
}
