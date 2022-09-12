using Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Helper
{
    public static class SortingDefinition
    {
        public static SortDefinition<T> TableSortingFilter<T>(string sortField = "", string sortDirection = "") where T : IEntity
        {
            var sort = Builders<T>.Sort.Descending("CreatedOn");

            if (!string.IsNullOrEmpty(sortField) && sortField.ToLower() != "undefined")
            {
                if (!string.IsNullOrEmpty(sortDirection))
                {
                    sortDirection = sortDirection.ToLower();

                    if (sortDirection.Equals("descending"))
                    {
                        sort = Builders<T>.Sort.Descending(sortField);
                    }
                    else
                    {
                        sort = Builders<T>.Sort.Ascending(sortField);
                    }

                }
            }

            return sort;
        }
    }
}
