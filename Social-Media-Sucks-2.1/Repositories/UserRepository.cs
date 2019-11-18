using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SocialMediaSucks2.Models;

namespace SocialMediaSucks2.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IOptions<SocialMediaSucksDatabaseSettings> settings) : base(settings)
        {
        }

        public async Task AddUser(User user)
        {
            try
            {
                await _context.Users.InsertOneAsync(user);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<User> GetUserById(string id, bool keepPassword)
        {
            try
            {
                if (keepPassword)
                {
                    return await _context.Users
                                .Find(user => user.Id == id)
                                .FirstOrDefaultAsync();
                }
                return await _context.Users
                                .Find(user => user.Id == id)
                                .Project(user => new User
                                {
                                    Id = user.Id,
                                    Username = user.Username,
                                    CreatedAt = user.CreatedAt
                                })
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<User> GetUserByUsername(string username, bool keepPassword)
        {
            try
            {
                if (keepPassword)
                {
                    return await _context.Users
                                .Find(user => user.Username == username)
                                .FirstOrDefaultAsync();
                }
                return await _context.Users
                                .Find(user => user.Username == username)
                                .Project(user => new User
                                {
                                    Id = user.Id,
                                    Username = user.Username,
                                    CreatedAt = user.CreatedAt
                                })
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}
