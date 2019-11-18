using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaSucks2.BusinessLogic;
using SocialMediaSucks2.Helpers;
using SocialMediaSucks2.Models;
using SocialMediaSucks2.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialMediaSucks2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHelper _tokenHelper;
        public UserController(IUserRepository uR, ITokenHelper tokenHelper)
        {
            _userRepository = uR;
            _tokenHelper = tokenHelper;
        }

        [HttpGet("{id}")]
        public async Task<ResultResponse<User>> Get(string id)
        {
            var userBL = new UserBL(_userRepository);
            User user;
            try
            {
                user = await userBL.GetUserById(id);
                return new ResultResponse<User>
                {
                    Success = true,
                    Item = user
                };
            }
            catch(Exception ex)
            {
                return GetErrorResponse<User>(ex, "Error getting user! Please try again.");
            }
        }
        [HttpGet("token")]
        public ResultResponse<bool> GetToken()
        {
            return new ResultResponse<bool>
            {
                Success = true,
                Item = true
            };
        }
        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<ResultResponse<User>> CreateUser([FromBody]User user)
        {
            var userBL = new UserBL(_userRepository);
            try
            {
                await userBL.AddUser(user);

                return new ResultResponse<User>
                {
                    Success = true,
                    Item = user,
                    Message = "Successfully created acccount!",
                    Token = _tokenHelper.GenerateToken(user)
                };
            }
            catch (Exception ex)
            {
                return GetErrorResponse<User>(ex, "Error creating user! Please try again.");
            }
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ResultResponse<User>> Authenticate([FromBody] AuthenticationModel credentials)
        {
            var userBL = new UserBL(_userRepository);
            try
            {
                var user = await userBL.Authenticate(credentials.Username, credentials.Password);
                return new ResultResponse<User>
                {
                    Success = true,
                    Item = user,
                    Token = _tokenHelper.GenerateToken(user)
                };
            }
            catch(Exception ex)
            {
                return GetErrorResponse<User>(ex, ex.Message);
            }
        }

        public class AuthenticationModel
        {
            public string Username;
            public string Password;
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
