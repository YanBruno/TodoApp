using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApp.Core.Entities;
using TodoApp.Core.Repositories;
using TodoApp.Infra.Contexts;

namespace TodoApp.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoAppContext _context;
        public TodoRepository(TodoAppContext context){
            _context = context;
        }
        public async Task<object> DeleteAsync(Todo model)
        {
            _context.Todos.Remove(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<Todo> GetByIdAsync(Guid id) => 
            await 
                _context
                    .Todos
                        .AsNoTracking()
                        .FirstOrDefaultAsync(todo => todo.Id == id);
        
        public async Task<IEnumerable<Todo>> GetTodosAsync() => 
            await _context.Todos.AsNoTracking().ToListAsync();
        

        public async Task<object> AddAsync(Todo model)
        {
            await _context.Todos.AddAsync(model);
            return await _context.SaveChangesAsync();
        }

        public async Task<object> UpdateAsync(Todo model)
        {
            _context.Todos.Update(model);
            return await _context.SaveChangesAsync();
        }
    }
}