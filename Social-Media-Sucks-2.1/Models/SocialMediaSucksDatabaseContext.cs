using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace SocialMediaSucks2.Models
{
    public class SocialMediaSucksDatabaseContext
    {
        private readonly IMongoDatabase _database;


        public SocialMediaSucksDatabaseContext(IOptions<SocialMediaSucksDatabaseSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<User> Users
        {
            get
            {
                return _database.GetCollection<User>("Users");
            }
        }
        public IMongoCollection<Post> Posts
        {
            get
            {
                return _database.GetCollection<Post>("Posts");
            }
        }
        public IMongoCollection<Comment> Comments
        {
            get
            {
                return _database.GetCollection<Comment>("Comments");
            }
        }
    }
}
