using AliChoixServer.Database;
using AliChoixServer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AliChoixServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MongoDbService m_mongoCrud;
        private readonly HttpClient m_OffClient;
        private readonly HttpClient m_VisionClient;

        public ProductController()
        {
            m_mongoCrud = new MongoDbService();
            m_OffClient = new HttpClient();
            m_VisionClient = new HttpClient();
            m_OffClient.BaseAddress = new Uri("https://world.openfoodfacts.org/api/v0/product/");
            m_VisionClient.BaseAddress = new Uri("http://localhost:1222/");
        }
        /// <summary>
        /// Informations on a product
        /// </summary>
        /// <response code="200">Product found</response>
        /// <response code="404">Product not found</response>
        [HttpGet]
        async public Task<ActionResult<OffMongoDbProduct>> Get(String universalProductCode)
        {
            try
            {
            OffMongoDbProduct product = m_mongoCrud.LoadDocumentById<OffMongoDbProduct>(universalProductCode);

            if (product != null && product.ImageUrl != null) return product;

            String serializedProduct = await FetchProductFromOffApi(universalProductCode);

            if (serializedProduct == null) return NotFound();
                
                OffApiProduct apiProduct = JsonConvert.DeserializeObject<OffApiProduct>(serializedProduct);

                if(apiProduct.Product == null) return NotFound();

                BsonDocument bsonProduct = BsonSerializer.Deserialize<BsonDocument>(apiProduct.Product.ToString());
                m_mongoCrud.ReplaceDocument<BsonDocument>(universalProductCode, bsonProduct, true);

                product = BsonSerializer.Deserialize<OffMongoDbProduct>(bsonProduct);

                return product;
            }
            catch(Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Add product to Alichoix Database
        /// </summary>
        /// <response code="200">Product correctly analysed</response>
        /// <response code="400">Bad request</response>
        [HttpPost]
        async public Task<ActionResult<OffMongoDbProduct>> Post(String universalProductCode, IFormFile file)
        {
            var httpRequest = ControllerContext.HttpContext.Request;

            if (universalProductCode == null || file == null) return BadRequest();


            using (var memoryStream = new MemoryStream())
            {
                //Get the file steam from the multiform data uploaded from the browser
                await file.CopyToAsync(memoryStream);

                //Build an multipart/form-data request to upload the file to Web API
                using var form = new MultipartFormDataContent();
                using var fileContent = new ByteArrayContent(memoryStream.ToArray());
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                form.Add(fileContent, "image", file.FileName);

                try
                {
                    var response = await m_VisionClient.PostAsync($"analyse", form);
                    string returnResult = await response.Content.ReadAsStringAsync();
                    Dictionary<string, List<string>> result = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(returnResult);
                    response.EnsureSuccessStatusCode();
                    
                    return new OffMongoDbProduct();
                }
                catch(Exception e)
                {
                    //TODO send an error
                    return new OffMongoDbProduct();
                }
            }
        }

        private async Task<String> FetchProductFromOffApi(string universalProductCode)
        {
            HttpResponseMessage response = await m_OffClient.GetAsync(universalProductCode + ".json");

            if (response.StatusCode != System.Net.HttpStatusCode.OK) return null;

            string productAsJson = await response.Content.ReadAsStringAsync();      

            return productAsJson;
        }
    }
}
