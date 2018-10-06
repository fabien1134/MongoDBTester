using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBTester.Entities
{
    public class CollegeMember 
    {
        public ObjectId Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("age")]
        public int Age { get; set; }
        [BsonElement("type")]
        public string Type { get; set; }
        [BsonElement("studentQualification")]
        public Studentqualification[] StudentQualification { get; set; }
    }
}
