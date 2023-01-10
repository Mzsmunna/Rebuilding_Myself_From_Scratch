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
using Utilities;
using System.Text.RegularExpressions;

namespace Repositories.Mongo
{
    public class IssueRepository : MongoDBBase<Issue>, IIssueRepository
    {
        private readonly IMongoCollection<Issue> _collection;
        
        public IssueRepository(IMongoDBContext context, IssueConfiguration entityConfig) : base(context, entityConfig)
        {
            _collection = mongoCollection;
        }

        public List<Issue> GetAllIssues()
        {
            var filter = Builders<Issue>.Filter.Empty;
            var sort = SortingDefinition.TableSortingFilter<Issue>(); //Builders<Issue>.Sort.Ascending("Title");
            return _collection.Find(filter).Sort(sort).ToList();
        }

        public List<dynamic> GetIssueStatByUserId(string userId)
        {
            //var filter = Builders<User>.Filter.Empty;

            int totalCount = 0;

            var results = _collection.AsQueryable()
                            //.OrderByDescending(e => e.Email)
                            .Where(x => !string.IsNullOrEmpty(x.AssignedId) && x.AssignedId.Equals(userId))
                            .GroupBy(x => x.Status)
                            .Select(g => new
                            {
                                //Id = g.First().Id,
                                Status = g.First().Status,
                                Count = g.Count()

                            }).ToList();

            return results.Cast<dynamic>().ToList();
        }

        public List<Issue> GetAllIssuesByAssigner(string assignerId)
        {
            var filter = Builders<Issue>.Filter.Empty;
            var sort = SortingDefinition.TableSortingFilter<Issue>();
            return _collection.Find(filter).Sort(sort).ToList();
        }

        public List<Issue> GetAllIssuesByAssigned(string assignedId)
        {
            var filter = Builders<Issue>.Filter.Empty;
            var sort = SortingDefinition.TableSortingFilter<Issue>();
            return _collection.Find(filter).Sort(sort).ToList();
        }

        public Issue GetIssuesById(string id)
        {
            var filter = Builders<Issue>.Filter.Eq("Id", id);
            return _collection.Find(filter).FirstOrDefault();
        }

        public Issue GetByTitle(string title)
        {
            var filter = Builders<Issue>.Filter.Empty;

            if (!string.IsNullOrEmpty(title) && title.ToLower() != "undefined")
            {
                title = title.ToLower();
                filter = filter & Builders<Issue>.Filter.Regex("Title", new BsonRegularExpression("/^" + title.Replace("+", @"\+") + "$/i"));
                return _collection.Find(filter).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public Issue Save(IEntity entity)
        {
            var issue = entity as Issue;

            if (issue != null)
            {
                if (issue.Status.ToLower().Equals("pending"))
                {
                    issue.IsActive = false;
                    issue.IsDeleted = false;
                    issue.IsCompleted = false;
                }
                else if (issue.Status.ToLower().Equals("in-progress"))
                {
                    issue.IsActive = true;
                    issue.IsDeleted = false;
                    issue.IsCompleted = false;
                }
                else if (issue.Status.ToLower().Equals("done"))
                {
                    issue.IsActive = true;
                    issue.IsCompleted = true;
                    issue.IsDeleted = false;
                }
                else if (issue.Status.ToLower().Equals("discarded"))
                {
                    issue.IsActive = false;
                    issue.IsCompleted = false;
                    issue.IsDeleted = true;
                }

                entity = issue;

                var result = SaveAsync(entity).GetAwaiter().GetResult();

                return issue;
            }

            return null;
        }

        public bool DeleteById(string _id)
        {
            var filter = BuildFilter(_id);
            //var data = _collection.Find(filter).FirstOrDefault();
            DeleteResult result = _collection.DeleteMany(filter);

            return true;
        }

        #region Common_Methods

        private FilterDefinition<Issue> BuildFilter(string _id, List<SearchField> searchQueries = null)
        {
            //var filter = Builders<T>.Filter.Empty;
            var filter = GenericFilter<Issue>.BuildDynamicFilter(_id, searchQueries);
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

        public async Task<long> GetAllIssueCount(List<SearchField> searchQueries = null)
        {
            var filter = BuildFilter(null, searchQueries);
            return await _collection.Find(filter).CountAsync().ConfigureAwait(false);
        }

        public async Task<List<Issue>> GetAllIssues(int currentPage, int pageSize, string sortField, string sortDirection, List<SearchField> searchQueries = null)
        {
            var filter = BuildFilter(null, searchQueries);
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
