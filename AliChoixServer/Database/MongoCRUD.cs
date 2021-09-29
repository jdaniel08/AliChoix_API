using AliChoixServer.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliChoixServer.Database
{
    public class MongoCRUD
    {
        private readonly string DATABASE_NAME = "off";
        private readonly string TABLE = "products";
        private IMongoDatabase db;

        public MongoCRUD()
        {
            var client = new MongoClient();
            db = client.GetDatabase(DATABASE_NAME);
        }

        public void InsertFoodItem(Product product)
        {
            //todo
        }

        public T LoadProductById<T>(string id)
        {
            var collection = db.GetCollection<T>(TABLE);
            var filter = Builders<T>.Filter.Eq("id", id);
            var product = collection.Find(filter).FirstOrDefault();
            return product;
        }

        public async Task<T> LoadProductByIdAsync<T>(string id)
        {
            var collection = db.GetCollection<T>(TABLE);
            var filter = Builders<T>.Filter.Eq("Id", id);

            return collection.FindAsync(filter).Result.First();
        }
    }
}
