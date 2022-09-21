using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IIssueRepository
    {
        List<Issue> GetAllIssues();
        List<Issue> GetAllIssuesByAssigner(string assignerId);
        List<Issue> GetAllIssuesByAssigned(string assignedId);
        Issue GetIssuesById(string id);
        Issue GetByTitle(string title);
        Issue Save(IEntity entity);
        bool DeleteById(string _id);

        #region Common_Methods

        Task<Issue> GetById(string _id);
        Task<List<Issue>> GetAllByField(string fieldName, string fieldValue);
        Task<long> GetAllIssueCount(List<SearchField> searchQueries = null);
        Task<List<Issue>> GetAllIssues(int currentPage, int pageSize, string sortField, string sortDirection, List<SearchField> searchQueries = null);
        int GetAllCount();
        string SaveMany(IEnumerable<Issue> records);

        #endregion
    }
}
