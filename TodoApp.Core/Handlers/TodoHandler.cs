using System.Threading.Tasks;
using TodoApp.Core.Commands;
using TodoApp.Core.Commands.Contracts;
using TodoApp.Core.Commands.TodoCommands;
using TodoApp.Core.Entities;
using TodoApp.Core.Handlers.Contract;
using TodoApp.Core.Repositories;
using TodoApp.Core.ValueObjects;

namespace TodoApp.Core.Handlers
{
    public class TodoHandler : 
        IHandler<CreateNewTodoCommand>,
        IHandler<AlterDoneTodoCommand>,
        IHandler<AlterTitleTodoCommand>,
        IHandler<DeleteTodoCommand>
    {

        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CreateNewTodoCommand command)
        {
            // FFF
            if(!command.Validate())
                return new GenericCommandResult("Ops, command inválido", false, null);


            //Criar VO's
            var title = new Title(command.Title);

            //Cria entidades
            var todo = new Todo(title);


            //Valida VO's e Entidades
            var validacao = true;
            if(!validacao)
                return new GenericCommandResult("Ops, command inválido", false, null);

            //Persiste no banco
            var result = await _repository.AddAsync(todo);

            return new GenericCommandResult("Todo criado com sucesso", true, todo);
        }

        public async Task<ICommandResult> Handle(AlterDoneTodoCommand command)
        {
            if(!command.Validate())
                return new GenericCommandResult("Ops, command inválido", false, null);


            //Recupera Todo
            var todo = await _repository.GetByIdAsync(command.Id);

            if(todo == null)
                return new GenericCommandResult("Ops, Todo inválido", false, null);

            //Valida VO's e Entidades
            var validacao = true;
            if(!validacao)
                return new GenericCommandResult("Ops, command inválido", false, null);

            //Altera status done
            todo.AlterDoneStatus();

            //Persiste no banco
            var result = await _repository.UpdateAsync(todo);

            return new GenericCommandResult("Todo alterado com sucesso", true, todo);

        }

        public async Task<ICommandResult> Handle(AlterTitleTodoCommand command)
        {
            if(!command.Validate())
                return new GenericCommandResult("Ops, command inválido", false, null);


            //Recupera Todo
            var todo = await _repository.GetByIdAsync(command.Id);

            if(todo == null)
                return new GenericCommandResult("Ops, Todo inválido", false, null);

            // Cria VO's
            var title = new Title(command.Title);

            //Valida VO's e Entidades
            var validacao = true;
            if(!validacao)
                return new GenericCommandResult("Ops, command inválido", false, null);

            //Altera status done
            todo.AlterTitle(title);

            //Persiste no banco
            var result = await _repository.UpdateAsync(todo);

            return new GenericCommandResult("Todo alterado com sucesso", true, todo);
        }

        public async Task<ICommandResult> Handle(DeleteTodoCommand command)
        {
            if(!command.Validate())
                return new GenericCommandResult("Ops, command inválido", false, null);


            //Recupera Todo
            var todo = await _repository.GetByIdAsync(command.Id);

            if(todo == null)
                return new GenericCommandResult("Ops, Todo inválido", false, null);

            //Persiste no banco
            var result = await _repository.DeleteAsync(todo);
            todo = null;

            return new GenericCommandResult("Todo deletado com sucesso", true, todo);
        }
    }
}