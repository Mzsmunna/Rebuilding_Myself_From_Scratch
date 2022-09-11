using MongoDB.Driver;

namespace Repositories.Mongo.Core
{
    public class MongoDBContext : IMongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(MongoDBSettings databaseSettings)
        {
            if(_database == null)
            {
                var client = new MongoClient(databaseSettings.ConnectionString);
                _database = client.GetDatabase(databaseSettings.DatabaseName);
            }
        }

        public IMongoCollection<TEntity> MapEntityWithCollection<TEntity>(string collectionName) where TEntity : class
        {
            if (!string.IsNullOrEmpty(collectionName))
                return _database.GetCollection<TEntity>(collectionName);

            return _database.GetCollection<TEntity>(typeof(TEntity).Name);
        }
    }
}
