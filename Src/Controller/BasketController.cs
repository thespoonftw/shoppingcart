using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingBasket.Controllers 
{
    [ApiController]
    public class BasketController : ControllerBase 
    {
        private BasketService basketService;

        public BasketController()
        {
            basketService = new BasketService();
        }

        [HttpGet]
        [Route("[controller]/{uriCode}")]
        public Basket Get(string uriCode) 
        {
            return basketService.CalculateBasket(uriCode);
        }        
    }
}
