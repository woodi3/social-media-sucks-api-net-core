using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialMediaSucks2.Models;

namespace SocialMediaSucks2.Repositories
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllComments();
        Task<List<Comment>> GetCommentsByPostId(string id);
        Task<List<Comment>> GetChildComments(string parentId);
        Task AddComment(Comment comment);
    }
}
