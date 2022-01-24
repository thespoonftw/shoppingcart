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
        private IBasketService basketService;

        public BasketController(IBasketService basketService)
        {
            this.basketService = basketService;
        }

        [HttpGet]
        [Route("[controller]/{uri}")]
        public Basket Get(string uri) 
        {
            return basketService.CalculateBasket(uri);
        }        
    }
}
