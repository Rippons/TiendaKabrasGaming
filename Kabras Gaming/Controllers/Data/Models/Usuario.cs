using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Kabras_Gaming.Controllers.Data.Models
{
    public class Usuario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // Esto permite que el Id se represente como un ObjectId
        public string Id { get; set; }

        public string Username { get; set; }
        
        public string Password { get; set; }
    }
}

