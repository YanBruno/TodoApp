using System.Threading.Tasks;
using TodoApp.Core.Commands.Contracts;

namespace TodoApp.Core.Handlers.Contract
{
    public interface IHandler<T> where T : ICommand{
        Task<ICommandResult> Handle(T command);
    }
}