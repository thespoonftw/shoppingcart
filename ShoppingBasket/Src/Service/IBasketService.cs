using ShoppingBasket.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket 
{
    public interface IBasketService
    {
        Basket CalculateBasket(string uriCode);
    }
}
