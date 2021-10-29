using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Shared.Entities;

namespace TodoApp.Core.Repositories
{
    public interface IRepository<T> where T : Entity{
        Task<object> AddAsync(T model); 
        Task<object> DeleteAsync(T model); 
        Task<object> UpdateAsync(T model);
        Task<IEnumerable<T>> GetTodosAsync();
        Task<T> GetByIdAsync(Guid id);
    }
}