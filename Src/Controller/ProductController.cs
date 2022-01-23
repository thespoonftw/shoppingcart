using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingBasket.Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase 
    {        
        [HttpGet]
        public IEnumerable<Product> Get() 
        {
            var database = new DatabaseReader();
            return database.GetAllProducts();
        }
    }
}
