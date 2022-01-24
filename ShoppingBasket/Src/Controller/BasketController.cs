using Microsoft.AspNetCore.Mvc;

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

        /// <summary>
        /// Converts the URI arguement into a basket object to be displayed on the front end.
        /// </summary>
        /// <param name="basketString">represents the state of the user's basket</param>
        /// <returns>Basket containing discounts and prices</returns>
        [HttpGet]
        [Route("[controller]/{basketString}")]
        public Basket Get(string basketString) 
        {
            return basketService.CalculateBasket(basketString);
        }        
    }
}
