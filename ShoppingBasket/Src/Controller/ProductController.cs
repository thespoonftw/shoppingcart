using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ShoppingBasket.Controllers
{
    [ApiController]    
    public class ProductController : ControllerBase 
    {
        private IDatabaseService databaseService;

        public ProductController(IDatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        /// <summary>
        /// Gets all products in the store from the database
        /// </summary>
        /// <returns>Collection of available products</returns>
        [HttpGet]
        [Route("[controller]")]
        public IEnumerable<Product> Get() 
        {
            return databaseService.GetAllProducts();
        }
    }
}
