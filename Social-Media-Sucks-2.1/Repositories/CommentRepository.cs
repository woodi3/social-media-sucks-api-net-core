using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SocialMediaSucks2.Models;

namespace SocialMediaSucks2.Repositories
{
    public class CommentRepository : BaseRepository, ICommentRepository
    {
        public CommentRepository(IOptions<SocialMediaSucksDatabaseSettings> settings)
            : base(settings)
        {
        }

        public async Task<List<Comment>> GetAllComments()
        {
            try
            {
                return await _context.Comments
                            .Find(_ => true)
                            .SortByDescending(c => c.CreatedAt)
                            .ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Comment>> GetCommentsByPostId(string postId)
        {
            try
            {
                return await _context.Comments
                            .Find(c => c.PostId == postId)
                            .SortByDescending(c => c.CreatedAt)
                            .ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Comment>> GetChildComments(string parentId)
        {
            try
            {
                return await _context.Comments
                            .Find(c => c.ParentCommentId == parentId)
                            .SortByDescending(c => c.CreatedAt)
                            .ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddComment(Comment comment)
        {
            try
            {
                await _context.Comments.InsertOneAsync(comment);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
