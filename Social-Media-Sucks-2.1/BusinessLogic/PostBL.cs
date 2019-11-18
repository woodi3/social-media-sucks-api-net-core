using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMediaSucks2.Models;
using SocialMediaSucks2.Repositories;

namespace SocialMediaSucks2.BusinessLogic
{
    public class PostBL : IPostBL
    {
        private readonly IPostRepository _postRepository;
        public PostBL(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<List<Post>> GetAllPosts()
        {
            try
            {
                return await _postRepository.GetAllPosts();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<Post>> GetPostsByUserId(string id)
        {
            try
            {
                return await _postRepository.GetPostsByUserId(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Post> GetPostById(string id)
        {
            try
            {
                return await _postRepository.GetPostById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddPost(Post post)
        {
            try
            {
                post.CreatedAt = DateTime.Now;
                await _postRepository.AddPost(post);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task SetCommentsForPosts(List<Post> posts, ICommentRepository commentRepository)
        {
            foreach(var post in posts)
            {
                try
                {
                    await SetCommentsOnPost(post, commentRepository);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        #region PRIVATE
        private async Task SetCommentsOnPost(Post post, ICommentRepository commentRepository)
        {
            try
            {
                post.Comments = await commentRepository.GetCommentsByPostId(post.Id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #endregion PRIVATE
    }
}
