using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocialMediaSucks2.Models
{
    public class Post : BaseDatabaseModel
    {
        public string Content { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        public List<Comment> Comments { get; set; }

        public Post()
        {
            Comments = new List<Comment>();
        }
    }
}
