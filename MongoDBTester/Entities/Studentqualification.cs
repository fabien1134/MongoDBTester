using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBTester.Entities
{
    public class Studentqualification
    {
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("grade")]
        public string Grade { get; set; }
    }
}
