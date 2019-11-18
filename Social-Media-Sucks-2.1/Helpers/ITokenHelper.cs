using System;
using SocialMediaSucks2.Models;

namespace SocialMediaSucks2.Helpers
{
    public interface ITokenHelper
    {
        string GenerateToken(User user);
    }
}
