using TodoApp.Core.Commands.Contracts;

namespace TodoApp.Core.Commands.TodoCommands
{
    public class CreateNewTodoCommand : ICommand
    {
        public string Title { get; set; }
        public bool Validate()
        {
           return true;
        }
    }
}