using System;
using TodoApp.Core.Commands.Contracts;

namespace TodoApp.Core.Commands.TodoCommands
{
    public class DeleteTodoCommand : ICommand{
        public Guid Id { get; set; }

        public bool Validate()
        {
            return true;
        }
    }
}