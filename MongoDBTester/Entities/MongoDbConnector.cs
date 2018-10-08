using MongoDB.Driver;
using System;

namespace MongoDBTester.Entities
{
    //This class is responsible for providing CRUD Operation capabilities
    public static class MongoDbConnector
    {
        #region Static Variables
        private static MongoClient m_mongoClient { get; set; }
        private static IMongoDatabase m_mongoDatabase { get; set; }
        #endregion

        #region Properties
        public static bool IsDatabaseInitialized { get; set; }
        #endregion

        public static void InitialiseDB()
        {
            IsDatabaseInitialized = false;
            m_mongoClient = new MongoClient("mongodb://localhost:27017");
            m_mongoDatabase = m_mongoClient.GetDatabase("DevServer");
            IsDatabaseInitialized = true;
        }

        public static IMongoCollection<CollegeMember> GetCollegeMembers() => m_mongoDatabase.GetCollection<CollegeMember>("CollegeMember");

        public static IMongoCollection<CollegeMemberType> GetCollegeMemberTypes() => m_mongoDatabase.GetCollection<CollegeMemberType>("CollegeMemberType");

        //Create a college Member
        public static void CreateCollegeMember(CollegeMember collegeMember)
        {
            IMongoCollection<CollegeMember> collection = m_mongoDatabase.GetCollection<CollegeMember>("CollegeMember");
            collection.InsertOne(collegeMember);
        }


        public static void DeleteCollegeMember(CollegeMember collegeMember)
        {
            IMongoCollection<CollegeMember> collection = m_mongoDatabase.GetCollection<CollegeMember>("CollegeMember");
            DeleteResult result = collection.DeleteOne(cMember => cMember.Id == collegeMember.Id);
            if (result.IsAcknowledged)
                if (result.DeletedCount == 0)
                    throw new Exception("Issue While Deleting College Member");
        }


        public static void UpdateCollegeMember(CollegeMember collegeMember)
        {
            IMongoCollection<CollegeMember> collection = m_mongoDatabase.GetCollection<CollegeMember>("CollegeMember");
            FilterDefinition<CollegeMember> filter = Builders<CollegeMember>.Filter.Eq(cMember => cMember.Id, collegeMember.Id);
            ReplaceOneResult result = collection.ReplaceOne(filter, collegeMember);
            if (!result.IsModifiedCountAvailable)
                throw new Exception("Failed To Update College Member");
        }
    }
}
