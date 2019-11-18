using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SocialMediaSucks2.Models;

namespace SocialMediaSucks2.Repositories
{
    public class PostRepository : BaseRepository,IPostRepository
    {
        public PostRepository(IOptions<SocialMediaSucksDatabaseSettings> settings)
            : base(settings)
        {
        }

        public async Task<List<Post>> GetAllPosts()
        {
            try
            {
                return await _context.Posts
                        .Find(_ => true)
                        .SortByDescending(p => p.CreatedAt)
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Post>> GetPostsByUserId(string userId)
        {
            try
            {
                return await _context.Posts
                            .Find(p => p.UserId == userId)
                            .SortByDescending(p => p.CreatedAt)
                            .ToListAsync();
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
                return await _context.Posts
                            .Find(p => p.Id == id)
                            .FirstOrDefaultAsync();
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
                await _context.Posts.InsertOneAsync(post);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
