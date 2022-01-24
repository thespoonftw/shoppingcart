using System;
using System.Collections.Generic;

namespace ShoppingBasket 
{
    public interface IDiscountService 
    {
        /// <summary>
        /// Calculates discounts for a given basket dictionary
        /// </summary>
        /// <param name="basketDictionary">Dictionary of items in a basket</param>
        /// <returns>Array of discounts in the basket, if any</returns>
        public BasketItem[] GetDiscounts(Dictionary<int, int> basketDictionary);
    }
}
