using System.Threading.Tasks;

namespace WebsiteManagement.Application.Abstractions.Commands
{
    public interface ICommandDispatcher
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <param name="command"></param>
        void DispatchCommand<TCommand>(TCommand command) where TCommand : ICommand;
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        Task DispatchCommandAsync<TCommand>(TCommand command) where TCommand : ICommand;
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        TReturn DispatchCommand<TCommand, TReturn>(TCommand command) where TCommand : ICommand;
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TCommand"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<TReturn> DispatchCommandAsync<TCommand, TReturn>(TCommand command) where TCommand : ICommand;
    }
}
