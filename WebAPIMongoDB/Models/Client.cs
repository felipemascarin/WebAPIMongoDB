using MongoDB.Bson.Serialization.Attributes;

namespace WebAPIMongoDB.Models
{
    public class Client
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public Address Address { get; set; }
    }
}