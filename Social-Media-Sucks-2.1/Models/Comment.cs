using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocialMediaSucks2.Models
{
    public class Comment : BaseDatabaseModel
    {
        public string Value { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string PostId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ParentCommentId { get; set; }

        public List<Comment> Comments { get; set; }

        public Comment()
        {
            Comments = new List<Comment>();
        }
    }
}
