using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliChoixServer.Model
{

    [BsonIgnoreExtraElements]
    public class Product
    {
        [BsonElement("_id")]
        public string Id { get; set; }

        [BsonElement("_keywords")]
        public string[] Keywords { get; set; }
    }
 }

