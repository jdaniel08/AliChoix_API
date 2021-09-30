using AliChoixServer.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliChoixServer.Database
{
    public class MongoDbService
    {
        private readonly string DATABASE_NAME = "off";
        private readonly string TABLE = "products";
        private readonly IMongoDatabase db;

        public MongoDbService()
        {
            var client = new MongoClient();
            db = client.GetDatabase(DATABASE_NAME);
        }

        public void InsertDocument<T>(T document)
        {
            IMongoCollection<T> collection = db.GetCollection<T>(TABLE);
            collection.InsertOne(document);
        }

        public T LoadDocumentById<T>(string id)
        {
            IMongoCollection<T> collection = db.GetCollection<T>(TABLE);
            FilterDefinition<T> filter = Builders<T>.Filter.Eq("_id", id);

            return collection.Find(filter).FirstOrDefault();
        }

        public async Task<T> LoadDocumentByIdAsync<T>(string id)
        {
            IMongoCollection<T> collection = db.GetCollection<T>(TABLE);
            FilterDefinition<T> filter = Builders<T>.Filter.Eq("Id", id);
            IAsyncCursor<T> cursor = await collection.FindAsync(filter);

            return cursor.First();
        }
    }
}
