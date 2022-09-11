using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(string clientId, string adminId);
        Task<User> GetUser(string id);
        Task<List<User>> GetAll();
        string Save(IEntity entity);
        Task<bool> UpdateUser(User user);
    }
}
