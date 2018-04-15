using System;
using System.Threading.Tasks;

namespace Weather.DAL.Repositories.Repositories
{
    public interface ICrudRepository<T>
    {
        Task<T> GetAsync(Guid id);
        Task CreateAsync(T product);
        Task UpdateAsync(T product);
        Task DeleteAsync(Guid id);
    }
}