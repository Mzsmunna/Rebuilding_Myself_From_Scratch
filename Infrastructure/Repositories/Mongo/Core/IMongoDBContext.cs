using MongoDB.Driver;

namespace Repositories.Mongo.Core
{
    public interface IMongoDBContext
    {
        IMongoCollection<TEntity> MapEntityWithCollection<TEntity>(string collectionName) where TEntity : class;
    }
}
