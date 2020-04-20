
using System.Threading;
using System.Threading.Tasks;

namespace WebsiteManagement.Application.Abstractions.Commands
{
    public interface ICommandHandler
    { }

    public interface ICommandHandler<in TCommand> : ICommandHandler where TCommand : ICommand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        void Handle(TCommand command);
    }

    public interface ICommandHandler<in TCommand, out TResult> : ICommandHandler where TCommand : ICommand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        TResult Handle(TCommand command);
    }
}
