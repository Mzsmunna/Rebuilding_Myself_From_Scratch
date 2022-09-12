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
        Issue GetIssuesById(string id);
        Issue GetByName(string name);
        Issue GetMaxOrganizationId();
        string Save(IEntity entity);

        #region Common_Methods

        Task<Issue> GetById(string _id);
        Task<List<Issue>> GetAllByField(string fieldName, string fieldValue);
        Task<List<Issue>> GetAll();
        Task<List<Issue>> GetAll(int currentPage, int pageSize);
        int GetAllCount();
        string SaveMany(IEnumerable<Issue> records);

        #endregion
    }
}
