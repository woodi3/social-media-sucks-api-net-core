using System;
using System.Threading.Tasks;
using SocialMediaSucks2.Models;
using SocialMediaSucks2.Repositories;
using bcrypt = BCrypt.Net.BCrypt;

namespace SocialMediaSucks2.BusinessLogic
{
    public class UserBL : IUserBL
    {
        private readonly IUserRepository _userRepository;

        public UserBL(IUserRepository uR)
        {
            _userRepository = uR;
        }

        public async Task<User> GetUserById(string id, bool keepPassword = false)
        {
            try
            {
                return await _userRepository.GetUserById(id, keepPassword);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetUserByUsername(string username, bool keepPassword = false)
        {
            try
            {
                return await _userRepository.GetUserByUsername(username, keepPassword);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddUser(User user)
        {
            try
            {
                var existingUser = await GetUserByUsername(user.Username);
                if(existingUser == null)
                {
                    user.CreatedAt = DateTime.Now;
                    user.Password = bcrypt.HashPassword(user.Password);
                    await _userRepository.AddUser(user);
                    user.Password = null;
                }
                else
                {
                    throw new Exception("Error creating user!");
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> Authenticate(string username, string password)
        {
            User user;
            try
            {
                user = await GetUserByUsername(username, keepPassword: true);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            var correctPassword = bcrypt.Verify(password, user.Password);
            if (correctPassword)
            {
                // authenticated
                return user;
            }

            // wrong credentials
            throw new Exception("Incorrect username or password. Please try again.");
        }
    }
}
