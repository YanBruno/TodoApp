using System;
using TodoApp.Core.Commands.Contracts;

namespace TodoApp.Core.Commands.TodoCommands
{
    public class AlterTitleTodoCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool Validate()
        {
            if(Id == null)
                return false;

            if(String.IsNullOrEmpty(Title))
                return false;

            return true;
        }
    }
}