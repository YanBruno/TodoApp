using System.Threading.Tasks;
using TodoApp.Shared.Entities;

namespace TodoApp.Core.Repositories
{
    public interface IRepository<T> where T : Entity{
        Task<object> SaveAsync(T model); 
        Task<object> DeleteAsync(T model); 
        Task<object> UpdateAsync(T model);

    }
}