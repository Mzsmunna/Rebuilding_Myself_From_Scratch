using Domain.Entities;
using Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using Repositories.Mongo.Configs;
using Repositories.Mongo.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Mongo
{
    public class UserRepository : MongoDBBase<User, UserConfiguration>, IUserRepository
    {
        private readonly IMongoCollection<User> _collection;
        public UserRepository(IMongoDBContext dbContext) : base(dbContext)
        {
            _collection = mongoCollection;
        }

        public async Task<User> GetUser(string clientId, string adminId)
        {
            var filter = Builders<User>.Filter.Empty;
            if (!string.IsNullOrEmpty(clientId))
                filter &= Builders<User>.Filter.Eq("ClientId", ObjectId.Parse(clientId));
            if (!string.IsNullOrEmpty(adminId))
                filter &= Builders<User>.Filter.Eq("AdminUserId", ObjectId.Parse(adminId));
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetAll()
        {
            var filter = Builders<User>.Filter.Empty;
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<User> GetUser(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            var filter = Builders<User>.Filter.Empty;
            filter &= Builders<User>.Filter.Eq("Id", ObjectId.Parse(id));

            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetUsers(string clientId, string adminId)
        {
            var filter = Builders<User>.Filter.Empty;
            if (!string.IsNullOrEmpty(clientId))
                filter &= Builders<User>.Filter.Eq("ClientId", ObjectId.Parse(clientId));
            if (!string.IsNullOrEmpty(adminId))
                filter &= Builders<User>.Filter.Eq("AdminUserId", ObjectId.Parse(adminId));
            return await _collection.Find(filter).ToListAsync();
        }

        public string Save(IEntity entity)
        {
            MongoDbOperationResult result = SaveAsync(entity).Result;
            return result.Id;
        }

        public async Task<bool> UpdateUser(User User)
        {
            ObjectId _id = ObjectId.Parse(User.Id);

            var filter = Builders<User>.Filter.Eq("Id", _id);
            var update = Builders<User>.Update
                //.Set(x => x.ClientId, User.ClientId)
                //.Set(x => x.AdminUserId, User.AdminUserId)
                .Set(x => x.IsActive, User.IsActive)
                //.Set(x => x.Guides, User.Guides)
                .Set("ModifiedOn", DateTime.Now);
            var result = await _collection.UpdateOneAsync(filter, update);
            return result.IsAcknowledged;
        }
    }
}
