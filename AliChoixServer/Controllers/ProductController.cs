using AliChoixServer.Database;
using AliChoixServer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        async public Task<ActionResult<AliChoixProduct>> Get(String universalProductCode)
        {
            OffMongoDbProduct product = m_mongoCrud.LoadDocumentById<OffMongoDbProduct>(universalProductCode);

            if (product != null && product.ImageUrl != null) return new AliChoixProduct(product);

            product = await FetchProductFromOffApi(universalProductCode);

            if (product == null) return NotFound();

            //todo save product in db

            return new AliChoixProduct(product);
        }

        /// <summary>
        /// Add product to Alichoix Database
        /// </summary>
        /// <response code="200">Product correctly analysed</response>
        /// <response code="400">Bad request</response>
        [HttpPost]
        public ActionResult<AliChoixProduct> Post(String universalProductCode, IFormFile image)
        {
            var httpRequest = ControllerContext.HttpContext.Request;

            if (universalProductCode == null || image == null) return BadRequest();

            //todo request the vision service to analyse the image
            //todo create a product from response
            //todo add the product to the db
            //todo return the product created

            return new AliChoixProduct(new OffMongoDbProduct());
        }

        private async Task<OffMongoDbProduct> FetchProductFromOffApi(string universalProductCode)
        {
            HttpResponseMessage response = await m_client.GetAsync(universalProductCode + ".json");

            if (!response.IsSuccessStatusCode) return null;

            string productAsJson = await response.Content.ReadAsStringAsync();
            OffApiProduct apiProduct = JsonConvert.DeserializeObject<OffApiProduct>(productAsJson);

            return apiProduct.Product;
        }
    }
}
