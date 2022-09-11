using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Mongo.Core
{
    public class MongoDBCore<T> where T : class
    {
        public string IdentityKey;

        private bool IsSuccess;

        private readonly IMongoCollection<T> collection;

        public MongoDBCore(IMongoCollection<T> baseCollection)
        {
            this.collection = baseCollection;
        }
        public async Task<bool> Save(T entity)
        {
            if (entity.GetType().GetProperty("CreatedOn") != null)
                entity.GetType().GetProperty("CreatedOn").SetValue(entity, DateTime.Now);
            await this.collection.InsertOneAsync(entity);
            IsSuccess = true;

            return IsSuccess;
        }

        public async Task<T> Get(MongoParam query)
        {
            var result = await this.collection.Find(query.Parameters).FirstOrDefaultAsync();

            return result == null ? null : result as T;
        }

        public async Task<T> SortAndGet(MongoParam query, string sortingFieldName)
        {
            var sort = Builders<T>.Sort.Descending(sortingFieldName);

            var result = await this.collection.Find(query.Parameters).Sort(sort).FirstOrDefaultAsync();

            return result == null ? null : result as T;
        }

        public async Task<List<T>> GetAll(MongoParam query)
        {
            var result = await this.collection.Find(query.Parameters).ToListAsync();

            return result == null ? null : result;
        }
    }
}
