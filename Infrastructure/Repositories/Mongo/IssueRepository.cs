using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using System.Threading.Tasks;
using Repositories.Mongo.Core;
using Domain.Entities;
using Repositories.Helper;
using Repositories.Mongo.Configs;
using Domain.Interfaces;

namespace Repositories.Mongo
{
    public class IssueRepository : MongoDBBase<Issue, IssueConfiguration>, IIssueRepository
    {
        private readonly IMongoCollection<Issue> _collection;
        
        public IssueRepository(IMongoDBContext context) : base(context)
        {
            _collection = mongoCollection;
        }

        public List<Issue> GetAllIssues()
        {
            var filter = Builders<Issue>.Filter.Empty;
            // filter = filter & Builders<Issue>.Filter.Eq("ParentOrganizationId", BsonNull.Value);
            var sort = Builders<Issue>.Sort.Ascending("Name");
            return _collection.Find(filter).Sort(sort).ToList();
        }

        public Issue GetIssuesById(string id)
        {
            var filter = Builders<Issue>.Filter.Eq("Id", id);
            return _collection.Find(filter).FirstOrDefault();
        }

        public Issue GetByName(string name)
        {
            var filter = Builders<Issue>.Filter.Empty;

            if (!string.IsNullOrEmpty(name) && name.ToLower() != "undefined")
            {
                name = name.ToLower();
                filter = filter & Builders<Issue>.Filter.Regex("Name", new BsonRegularExpression("/^" + name.Replace("+", @"\+") + "$/i"));
                return _collection.Find(filter).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public Issue GetMaxOrganizationId()
        {
            var filter = Builders<Issue>.Filter.Empty;
            var sort = SortingDefinition.TableSortingFilter<Issue>("OrganizationId", "Descending");
            return _collection.Find(filter).Sort(sort).FirstOrDefault();
        }

        public string Save(IEntity entity)
        {
            var result = SaveAsync(entity).GetAwaiter().GetResult();
            return result.Id;
        }

        #region Common_Methods

        private FilterDefinition<Issue> BuildFilter(string _id)
        {
            var filter = Builders<Issue>.Filter.Empty;

            if (!string.IsNullOrEmpty(_id) && _id.ToLower() != "undefined")
            {
                filter = filter & Builders<Issue>.Filter.Eq("_id", _id);
            }

            return filter;
        }

        public async Task<Issue> GetById(string _id)
        {
            var filter = BuildFilter(_id);
            return await _collection.Find(filter).FirstOrDefaultAsync().ConfigureAwait(false);

        }

        public async Task<List<Issue>> GetAllByField(string fieldName, string fieldValue)
        {
            var filter = Builders<Issue>.Filter.Eq(fieldName, fieldValue);
            var result = await _collection.Find(filter).ToListAsync().ConfigureAwait(false);
            //var result = await _collection.Find(filter).FirstOrDefaultAsync().ConfigureAwait(false);
            return result;
        }

        public async Task<List<Issue>> GetAll()
        {
            var filter = BuildFilter(null);
            return await _collection.Find(filter).ToListAsync().ConfigureAwait(false);
        }

        public async Task<List<Issue>> GetAll(int currentPage, int pageSize)
        {
            var filter = BuildFilter(null);
            return await _collection.Find(filter).Skip(currentPage * pageSize).Limit(pageSize).ToListAsync().ConfigureAwait(false);
        }

        public string SaveMany(IEnumerable<Issue> records)
        {
            var returnVal = string.Empty;
            _collection.InsertMany(records);
            return returnVal;
        }

        public int GetAllCount()
        {
            int count = 0;
            var filter = BuildFilter(null);
            count = Convert.ToInt32(_collection.Find(filter).Count());
            return count;
        }

        #endregion
    }
}
