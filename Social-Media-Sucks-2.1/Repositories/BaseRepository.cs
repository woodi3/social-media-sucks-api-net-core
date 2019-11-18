using System;
using Microsoft.Extensions.Options;
using SocialMediaSucks2.Models;

namespace SocialMediaSucks2.Repositories
{
    public class BaseRepository
    {
        protected readonly SocialMediaSucksDatabaseContext _context;
        public BaseRepository(IOptions<SocialMediaSucksDatabaseSettings> settings)
        {
            _context = new SocialMediaSucksDatabaseContext(settings);
        }
    }
}
