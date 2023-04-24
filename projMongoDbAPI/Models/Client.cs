using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace projMongoDbAPI.Models
{
    public class Client
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
