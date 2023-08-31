using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Entities
{
    public class ActiveUser
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; } = string.Empty;


        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime LastActive { get; set; } = DateTime.UtcNow;
    }
}
