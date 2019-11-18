using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocialMediaSucks2.Models
{
    public class User : BaseDatabaseModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public User()
        {
        }
    }
}
