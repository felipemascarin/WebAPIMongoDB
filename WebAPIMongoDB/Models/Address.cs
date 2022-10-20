using MongoDB.Bson.Serialization.Attributes;

namespace WebAPIMongoDB.Models
{
    public class Address
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}