using System;
using System.Threading.Tasks;
using SocialMediaSucks2.Models;

namespace SocialMediaSucks2.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserById(string id, bool keepPassword);

        Task<User> GetUserByUsername(string username, bool keepPassword);

        Task AddUser(User user);
        
    }
}
