using Chat.Application.Interfaces.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Chat.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public BaseRepository(string collection)
        {
            var client = new MongoClient("mongodb+srv://edwardabladei:fshny83wWhLAccM3@chatapp.amqs8gw.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("ChatDatabase");

            _collection = database.GetCollection<T>(collection);
        }

        public async Task CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task<bool> DeleteAsync(ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);

            if (filter != null)
            {
                await _collection.DeleteManyAsync(filter);
                return true;
            }

            return false;
        }

        public async Task<T> GetByIdAsync(ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);

            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<bool> UpdateAsync(ObjectId id,T document)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);

            if (filter != null)
            {
                await _collection.ReplaceOneAsync(filter, document);
                return true;
            }

            return false;
        }
    }
}
