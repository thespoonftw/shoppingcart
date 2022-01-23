using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingBasket.Controllers 
{
    [ApiController]    
    public class ProductController : ControllerBase 
    {        
        [HttpGet]
        [Route("[controller]")]
        public IEnumerable<Product> Get() 
        {
            var database = new DatabaseService();
            return database.GetAllProducts();
        }
    }
}
