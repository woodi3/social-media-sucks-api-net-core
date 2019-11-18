using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMediaSucks2.Models;

namespace SocialMediaSucks2.BusinessLogic
{
    public interface IPostBL
    {
        Task<List<Post>> GetAllPosts();

        Task<List<Post>> GetPostsByUserId(string id);

        Task<Post> GetPostById(string id);

        Task AddPost(Post post);
    }
}
