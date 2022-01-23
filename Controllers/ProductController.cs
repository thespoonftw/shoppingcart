using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingBasket.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase {        

        private readonly ILogger<WeatherForecastController> _logger;

        public ProductController(ILogger<WeatherForecastController> logger) {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get() {
            return DatabaseReader.GetAllProducts();
        }
    }
}
