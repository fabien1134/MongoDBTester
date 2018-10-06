using MongoDB.Driver;

namespace MongoDBTester.Entities
{
    public static class MongoDbConnector
    {
        private static MongoClient MongoClient { get; set; }
        public static IMongoDatabase MongoDatabase { get; set; }
        public static void InitialiseDB()
        {
            MongoClient = new MongoClient("mongodb://localhost:27017");
            MongoDatabase = MongoClient.GetDatabase("DevServer");
        }
    }
}
