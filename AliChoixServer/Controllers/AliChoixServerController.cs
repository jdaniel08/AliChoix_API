using AliChoixServer.Database;
using AliChoixServer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliChoixServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AliChoixServerController : ControllerBase
    {
        private readonly MongoCRUD m_mongoCrud;
        public AliChoixServerController()
        {
            m_mongoCrud = new MongoCRUD();
        }

        /// <summary>
        /// Analyse an image associated to a Universal Product Code and return informations on the product find in the image
        /// </summary>
        /// <response code="200">Product correctly analysed</response>
        /// <response code="400">The server could not understand the request due to invalid payload</response>
        /// <response code="452">Product not found in the Database</response>
        [HttpGet]
        public string Get(String universalProductCode)
        {
            Product product = m_mongoCrud.LoadProductById<Product>(universalProductCode);
            return "";
        }

        /// <summary>
        /// Analyse an image associated to a Universal Product Code and return informations on the product find in the image
        /// </summary>
        /// <response code="200">Product correctly analysed</response>
        /// <response code="400">The server could not understand the request due to invalid payload</response>
        /// <response code="453">Product already present in the Server Database, use the get method</response>
        /// <response code="454">The server could not analyse the image provided</response>
        [HttpPost]
        public string Post(String universalProductCode, IFormFile image)
        {
            var httpRequest = ControllerContext.HttpContext.Request;
            //todo request the vision service to analyse the image
            return image.FileName;
        }
    }
}
