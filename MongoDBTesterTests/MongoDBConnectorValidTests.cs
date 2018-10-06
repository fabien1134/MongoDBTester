using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDBTester.Entities;

namespace MongoDBTesterTests
{
    [TestClass]
    public class MongoDBConnectorValidTests
    {
        [TestMethod]
        public void ValidDBConnection()
        {
            //Arrange
            bool dbConnectionError = false;

            //Act
            try
            {
                MongoDbConnector.InitialiseDB();
            }
            catch (Exception)
            {
                dbConnectionError = true;
            }

            //Assert
            Assert.AreEqual(false, dbConnectionError);
        }
    }
}
