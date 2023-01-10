using Domain.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using Repositories.Mongo.Configs;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Repositories.Mongo.Core
{
    public class MongoDBBase<T> where T : class
    {
        protected readonly IMongoCollection<T> mongoCollection;

        public MongoDBBase(IMongoDBContext dBContext, IEntityConfiguration entityConfig)
        {
            string collectionName = entityConfig.Register();

            if (string.IsNullOrEmpty(collectionName))
            {
                throw new Exception("Collection Name Should Not be Null");
            }

            mongoCollection = dBContext.MapEntityWithCollection<T>(collectionName);
        }

        internal async Task<MongoDbOperationResult> SaveAsync(IEntity entity)
        {
            var _entity = entity as T;
            var _id = _entity.GetType().GetProperty("Id").GetValue(_entity, null);

            if (_id != null && !string.IsNullOrEmpty(_id.ToString()))
            {
                BsonDocument query = new BsonDocument {
                    { "_id" , ObjectId.Parse(_id.ToString()) }
                };

                if (_entity.GetType().GetProperty("ModifiedOn") != null)
                    _entity.GetType().GetProperty("ModifiedOn").SetValue(_entity, DateTime.Now);

                var result = await mongoCollection.ReplaceOneAsync(query, _entity).ConfigureAwait(false);
                return new MongoDbOperationResult() { Id = _id.ToString(), IsCompleted = result.IsAcknowledged };
            }
            else
            {
                var _generatedId = ObjectId.GenerateNewId().ToString();
                if (_entity.GetType().GetProperty("CreatedOn") != null)
                    _entity.GetType().GetProperty("CreatedOn").SetValue(_entity, DateTime.Now);

                if (_entity.GetType().GetProperty("ModifiedOn") != null)
                    _entity.GetType().GetProperty("ModifiedOn").SetValue(_entity, DateTime.Now);

                _entity.GetType().GetProperty("Id").SetValue(_entity, _generatedId);
                await mongoCollection.InsertOneAsync(_entity).ConfigureAwait(false);

                return new MongoDbOperationResult() { Id = _generatedId, IsCompleted = true };
            }
        }

        internal async Task<MongoDbOperationResult> SaveManyAsync(List<IEntity> entities)
        {
            List<T> _entities = entities.ConvertAll(x => x as T);

            // initialise write model to hold list of our upsert tasks
            var dataModels = new List<WriteModel<T>>();

            foreach(var _entity in _entities)
            {           
                var _id = _entity.GetType().GetProperty("Id").GetValue(_entity, null);

                if (_id != null && !string.IsNullOrEmpty(_id.ToString()))
                {
                    BsonDocument query = new BsonDocument {
                        { "_id" , ObjectId.Parse(_id.ToString()) }
                    };

                    if (_entity.GetType().GetProperty("ModifiedOn") != null)
                        _entity.GetType().GetProperty("ModifiedOn").SetValue(_entity, DateTime.Now);

                    // use ReplaceOneModel with property IsUpsert set to true to upsert whole documents
                    dataModels.Add(new ReplaceOneModel<T>(query, _entity) { IsUpsert = true });
                }
                else
                {
                    var _generatedId = ObjectId.GenerateNewId().ToString();

                    if (_entity.GetType().GetProperty("CreatedOn") != null)
                        _entity.GetType().GetProperty("CreatedOn").SetValue(_entity, DateTime.Now);

                    if (_entity.GetType().GetProperty("ModifiedOn") != null)
                        _entity.GetType().GetProperty("ModifiedOn").SetValue(_entity, DateTime.Now);

                    _entity.GetType().GetProperty("Id").SetValue(_entity, _generatedId);

                    dataModels.Add(new InsertOneModel<T>(_entity));
                }
            }

            var result = await mongoCollection.BulkWriteAsync(dataModels);
            return new MongoDbOperationResult() { Id = string.Empty, IsCompleted = result.IsAcknowledged };
        }

        internal async Task<MongoDbOperationResult> DeleteAsync(IEntity entity)
        {
            var _entity = entity as T;
            var _id = _entity.GetType().GetProperty("Id").GetValue(_entity, null);

            BsonDocument query = new BsonDocument {
                    { "_id" , ObjectId.Parse(_id.ToString()) }
                };

            var result = await mongoCollection.DeleteOneAsync(query).ConfigureAwait(false);
            return new MongoDbOperationResult() { Id = _id.ToString(), IsCompleted = result.IsAcknowledged };
        }
    }
}
