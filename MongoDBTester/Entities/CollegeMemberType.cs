using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBTester.Entities
{
    public class CollegeMemberType
    {
        public ObjectId Id { get; set; }
        [BsonElement("type")]
        public string Type { get; set; }
    }
}
