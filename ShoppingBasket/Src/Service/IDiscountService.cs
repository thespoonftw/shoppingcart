using System;
using System.Collections.Generic;

namespace ShoppingBasket 
{
    public interface IDiscountService 
    {
        public BasketItem[] GetDiscounts(Dictionary<int, int> basketDictionary);
    }
}
