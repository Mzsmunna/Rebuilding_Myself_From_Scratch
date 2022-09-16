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
            var sort = SortingDefinition.TableSortingFilter<Issue>(); //Builders<Issue>.Sort.Ascending("Title");
            return _collection.Find(filter).Sort(sort).ToList();
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

        public string Save(IEntity entity)
        {
            var result = SaveAsync(entity).GetAwaiter().GetResult();
            return result.Id;
        }

        #region Common_Methods

        private FilterDefinition<Issue> BuildFilter(string _id, List<SearchField> searchQueries = null)
        {
            var filter = Builders<Issue>.Filter.Empty;

            if (!string.IsNullOrEmpty(_id) && _id.ToLower() != "undefined")
            {
                filter = filter & Builders<Issue>.Filter.Eq("_id", _id);
            }

            if (searchQueries != null && searchQueries.Count > 0)
            {
                foreach (var query in searchQueries)
                {
                    if (!string.IsNullOrEmpty(query.Key) && !string.IsNullOrEmpty(query.Value))
                    {
                        if (query.IsEncrypted)
                        {
                            filter = filter & Builders<Issue>.Filter.Eq(query.Key, query.Value);
                        }
                        else if (query.IsBoolean)
                        {
                            if (query.Value.ToLower().Equals("true") || query.Value.ToLower().Equals("1"))
                            {
                                filter = filter & Builders<Issue>.Filter.Eq(query.Key, true);
                            }
                            else
                            {
                                filter = filter & Builders<Issue>.Filter.Ne(query.Key, true);
                            }
                        }
                        else if (query.IsDateTime)
                        {
                            var date = CommonHelperUtility.GetDateFromString(query.Value);

                            if (date.HasValue)
                            {
                                date = date.Value.ToLocalTime();
                                filter &= Builders<Issue>.Filter.Eq(query.Key, date);
                            }                         
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(query.DataSeparator))
                            {
                                List<string> dataList = new List<string>();
                                dataList.AddRange(query.Value.Split(query.DataSeparator).Select(i => i));

                                if (dataList.Count > 0 && query.IsCaseSensitive)
                                {
                                    if (query.IsPartialMatch)
                                    {
                                        dataList = dataList.ConvertAll(x => "/^" + x.Replace("+", @"\+").ToLower() + "$/i");
                                    }

                                    filter = filter & new BsonDocument(query.Key, new BsonDocument("$in", new BsonArray(dataList)));
                                }
                                else if (dataList.Count > 0 && !query.IsCaseSensitive)
                                {
                                    dataList = dataList.ConvertAll(x => x.Replace("(", @"\(").Replace(")", @"\)").ToLower());

                                    if (query.IsPartialMatch)
                                    {
                                        dataList = dataList.ConvertAll(x => "/^" + x.Replace("+", @"\+").ToLower() + "$/i");
                                    }

                                    var regexFilter = "(" + string.Join("|", dataList) + ")";
                                    filter = filter & Builders<Issue>.Filter.Regex(query.Key, new BsonRegularExpression(new Regex(regexFilter, RegexOptions.IgnoreCase))); // | RegexOptions.IgnorePatternWhitespace
                                }
                            }
                            else
                            {
                                if (query.IsCaseSensitive)
                                {
                                    if (query.IsPartialMatch)
                                    {
                                        filter = filter & Builders<Issue>.Filter.Regex(query.Key, new BsonRegularExpression("/^" + query.Value.Replace("+", @"\+") + "$/i"));
                                    }
                                    else
                                    {
                                        filter = filter & Builders<Issue>.Filter.Eq(query.Key, query.Value);
                                    }
                                }
                                else
                                {
                                    if (query.IsPartialMatch)
                                    {
                                        query.Value = query.Value.Replace("(", @"\(").Replace(")", @"\)").ToLower();
                                        query.Value = "/^" + query.Value.Replace("+", @"\+").ToLower() + "$/i";
                                        var regexFilter = "(" + query.Value + ")";
                                        filter = filter & Builders<Issue>.Filter.Regex(query.Key, new BsonRegularExpression(new Regex(regexFilter, RegexOptions.IgnoreCase)));
                                    }
                                    else
                                    {
                                        query.Value = query.Value.Replace("(", @"\(").Replace(")", @"\)").ToLower();
                                        var regexFilter = "(" + query.Value + ")";
                                        filter = filter & Builders<Issue>.Filter.Regex(query.Key, new BsonRegularExpression(new Regex(regexFilter, RegexOptions.IgnoreCase)));
                                    }
                                }
                            }
                        }
                    }
                }
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

        public async Task<List<Issue>> GetAll(int currentPage, int pageSize, string sortField, string sortDirection, List<SearchField> searchQueries = null)
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
