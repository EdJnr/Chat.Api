using MongoDB.Bson;
using MongoDB.Driver;

namespace Chat.Application.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetByIdAsync(ObjectId id);

        Task CreateAsync(T entity);

        Task<bool> UpdateAsync(ObjectId id, T document);

        Task<bool> DeleteAsync(ObjectId id);
    }
}
