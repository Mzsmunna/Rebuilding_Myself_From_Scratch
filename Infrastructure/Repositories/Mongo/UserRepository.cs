using Domain.Entities;
using Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using Repositories.Helper;
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

        private FilterDefinition<User> BuildFilter(string id, List<SearchField> searchQueries = null)
        {
            //var filter = Builders<T>.Filter.Empty;
            var filter = GenericFilter<User>.BuildDynamicFilter(id, searchQueries);
            return filter;
        }

        public async Task<User> LoginUser(string email, string password)
        {
            var filter = Builders<User>.Filter.Empty;
            filter &= Builders<User>.Filter.Eq(x => x.IsActive, true);

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                filter &= Builders<User>.Filter.Eq(x => x.Email, email);
                filter &= Builders<User>.Filter.Eq(x => x.Password, password);

                return await _collection.Find(filter).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<User> RegisterUser(string email)
        {
            var filter = Builders<User>.Filter.Empty;
            filter &= Builders<User>.Filter.Eq(x => x.IsActive, true);

            if (!string.IsNullOrEmpty(email))
            {
                filter &= Builders<User>.Filter.Eq(x => x.Email, email);

                var user = await _collection.Find(filter).FirstOrDefaultAsync();
                
                if (user != null)
                    user.Password = string.Empty;

                return user;
            }

            return null;
        }

        public async Task<long> GetAllUserCount(List<SearchField> searchQueries = null)
        {
            var filter = BuildFilter(null, searchQueries);
            return await _collection.Find(filter).CountAsync().ConfigureAwait(false);
        }

        public async Task<List<User>> GetAllUsers(int currentPage, int pageSize, string sortField, string sortDirection, List<SearchField> searchQueries = null)
        {
            var filter = BuildFilter(null, searchQueries);
            return await _collection.Find(filter).Skip(currentPage* pageSize).Limit(pageSize).ToListAsync().ConfigureAwait(false);
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

        public User Save(IEntity entity)
        {
            MongoDbOperationResult result = SaveAsync(entity).Result;
            var user = GetUser(result.Id).Result;
            return user;
        }

        public bool DeleteById(string _id)
        {
            var filter = BuildFilter(_id);
            //var data = _collection.Find(filter).FirstOrDefault();
            DeleteResult result = _collection.DeleteMany(filter);

            return true;
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
