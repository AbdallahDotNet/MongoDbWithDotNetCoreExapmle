using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDb
{
    public class DataContext
    {
        public IMongoDatabase CreateConnection()
        {
            var settings = MongoClientSettings.FromConnectionString("ConnectionString");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("learnMongo");

            return database;
        }
    }
}
