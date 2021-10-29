using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Core.Commands.TodoCommands;
using TodoApp.Core.Commands.Contracts;
using TodoApp.Core.Entities;
using TodoApp.Core.Handlers;
using TodoApp.Core.Repositories;
using System;

namespace TodoApp.Api.Controllers
{
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        private readonly TodoHandler _handler;
        private readonly ITodoRepository _repository;

        public TodoController([FromServices]TodoHandler handler, [FromServices] ITodoRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpGet]   
        [Route("all")]
        public async Task<IEnumerable<Todo>> GetAll(){
            
            return await _repository.GetTodosAsync();
        }

        [HttpGet]   
        [Route("{id:Guid}")]
        public async Task<Todo> GetById([FromRoute] Guid id){
            
            return await _repository.GetByIdAsync(id);
        }
        [HttpPut]   
        [Route("{id:Guid}/done")]
        public async Task<ICommandResult> AlterDone([FromRoute] AlterDoneTodoCommand command){
            
            return await _handler.Handle(command);
        }
        [HttpPut]   
        [Route("{id:Guid}/title")]
        public async Task<ICommandResult> AlterTitle([FromBody] AlterTitleTodoCommand command, [FromRoute]Guid id){
            command.Id = id;
            return await _handler.Handle(command);
        }

        [HttpPost]   
        [Route("new")]
        public async Task<ICommandResult> Post([FromBody] CreateNewTodoCommand command){
            return await _handler.Handle(command);
        }
    }
}