using System;
using System.Threading.Tasks;
using SocialMediaSucks2.Models;

namespace SocialMediaSucks2.BusinessLogic
{
    public interface IUserBL
    {
        Task<User> GetUserById(string id, bool keepPassword = false);
        Task<User> GetUserByUsername(string username, bool keepPassword = false);
        Task AddUser(User user);
    }
}
