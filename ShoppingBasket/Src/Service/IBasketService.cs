using ShoppingBasket.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket 
{
    public interface IBasketService
    {
        /// <summary>
        /// Creates a populated Basket object from a dictionary of basket contents. To be sent to be displayed on front end.
        /// </summary>
        /// <param name="basketDictionary">Dictionary of objects in the basket. Key is productId, value is amount of object.</param>
        /// <returns>Contents of basket, including total and discounts.</returns>
        Basket CalculateBasket(Dictionary<int, int> basketDictionary);
    }
}
