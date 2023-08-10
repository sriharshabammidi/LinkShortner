using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace LinkShortner.Models
{
    public class Link
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? OriginalLink { get; set; }

        public string? LinkIdentifier { get; set; }

        public DateTime Expiry { get; set; }
    }
}
