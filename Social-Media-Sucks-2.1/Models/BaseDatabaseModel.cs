using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocialMediaSucks2.Models
{
    public class BaseDatabaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonDateTimeOptions]
        public DateTime CreatedAt { get; set; }
    }
}
