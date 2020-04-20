
namespace WebsiteManagement.Application.Abstractions.Commands
{
    public interface ICommandPrecondition<in TCommand> where TCommand : ICommand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        CommandPreconditionCheckResult Check(TCommand command);
    }
}
