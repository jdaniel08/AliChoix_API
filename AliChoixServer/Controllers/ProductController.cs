using AliChoixServer.Database;
using AliChoixServer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AliChoixServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MongoDbService m_mongoCrud;
        private readonly HttpClient m_client;
        public ProductController()
        {
            m_mongoCrud = new MongoDbService();
            m_client = new HttpClient();
            m_client.BaseAddress = new Uri("https://world.openfoodfacts.org/api/v0/product/");
        }
        /// <summary>
        /// Informations on a product
        /// </summary>
        /// <response code="200">Product found</response>
        /// <response code="404">Product not found</response>
        [HttpGet]
        async public Task<ActionResult<OffMongoDbProduct>> Get(String universalProductCode)
        {
            OffMongoDbProduct product = m_mongoCrud.LoadDocumentById<OffMongoDbProduct>(universalProductCode);

            if (product != null && product.ImageUrl != null) return product;

            String serializedProduct = await FetchProductFromOffApi(universalProductCode);

            if (serializedProduct == null) return NotFound();

            OffApiProduct apiProduct = JsonConvert.DeserializeObject<OffApiProduct>(serializedProduct);
            BsonDocument bsonProduct = BsonSerializer.Deserialize<BsonDocument>(apiProduct.Product.ToString());
            m_mongoCrud.ReplaceDocument<BsonDocument>(universalProductCode, bsonProduct, true);

            product = BsonSerializer.Deserialize<OffMongoDbProduct>(bsonProduct);

            return product;
        }

        /// <summary>
        /// Add product to Alichoix Database
        /// </summary>
        /// <response code="200">Product correctly analysed</response>
        /// <response code="400">Bad request</response>
        [HttpPost]
        public ActionResult<OffMongoDbProduct> Post(String universalProductCode)
        {
            var httpRequest = ControllerContext.HttpContext.Request;

            if (universalProductCode == null || httpRequest.Form.Files.Count == 0) return BadRequest();

            //todo request the vision service to analyse the image
            //todo create a product from response
            //todo add the product to the db
            //todo return the product created

            return new OffMongoDbProduct();
        }

        private async Task<String> FetchProductFromOffApi(string universalProductCode)
        {
            HttpResponseMessage response = await m_client.GetAsync(universalProductCode + ".json");

            if (response.StatusCode != System.Net.HttpStatusCode.OK) return null;

            string productAsJson = await response.Content.ReadAsStringAsync();      

            return productAsJson;
        }
    }
}
