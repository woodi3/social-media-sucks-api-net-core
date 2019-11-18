using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaSucks2.BusinessLogic;
using SocialMediaSucks2.Models;
using SocialMediaSucks2.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialMediaSucks2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class PostsController : BaseController
    {
        IPostRepository _postRepository;
        ICommentRepository _commentRepository;

        public PostsController(IPostRepository pR, ICommentRepository cR)
        {
            _postRepository = pR;
            _commentRepository = cR;
        }
        // GET: api/posts
        [HttpGet]
        public async Task<ResultResponse<List<Post>>> Get()
        {
            var postBL = new PostBL(_postRepository);
            try
            {
                var posts = await postBL.GetAllPosts();

                await postBL.SetCommentsForPosts(posts, _commentRepository);

                return new ResultResponse<List<Post>>
                {
                    Success = true,
                    Item = posts
                };
            }
            catch(Exception ex)
            {
                return GetErrorResponse<List<Post>>(ex, "Error getting posts!");
            }
        }

        [HttpGet("{id}")]
        public async Task<ResultResponse<Post>> GetPostById(string id)
        {
            var postBL = new PostBL(_postRepository);
            try
            {
                var post = await postBL.GetPostById(id);

                await postBL.SetCommentsForPosts(new List<Post> { post }, _commentRepository);

                return new ResultResponse<Post>
                {
                    Success = true,
                    Item = post
                };
            }
            catch (Exception ex)
            {
                return GetErrorResponse<Post>(ex, "Error getting post!");
            }
        }
        [HttpGet("{userId}")]
        public async Task<ResultResponse<List<Post>>> GetPostsByUserId(string userId)
        {
            var postBL = new PostBL(_postRepository);
            try
            {
                var posts = await postBL.GetPostsByUserId(userId);
                await postBL.SetCommentsForPosts(posts, _commentRepository);
                return new ResultResponse<List<Post>>
                {
                    Success = true,
                    Item = posts
                };
            }
            catch (Exception ex)
            {
                return GetErrorResponse<List<Post>>(ex, "Error getting post!");
            }
        }

        // POST api/values
        [HttpPost("create")]
        public async Task<ResultResponse<Post>> Post([FromBody]Post post)
        {
            var postBL = new PostBL(_postRepository);
            try
            {
                await postBL.AddPost(post);
                return new ResultResponse<Post>
                {
                    Success = true,
                    Item = post
                };
            }
            catch (Exception ex)
            {
                return GetErrorResponse<Post>(ex, "Error creating post! Please try again.");
            }
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
