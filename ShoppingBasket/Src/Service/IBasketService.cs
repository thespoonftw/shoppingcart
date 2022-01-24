using ShoppingBasket.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket 
{
    public interface IBasketService
    {
        /// <summary>
        /// Creates a populated Basket object from URI arguement. To be sent to be displayed on front end.
        /// </summary>
        /// <param name="basketString">Basket contents in form of string. Items seperated by _ and amounts seperated by x</param>
        /// <returns>Contents of basket, including total and discounts.</returns>
        Basket CalculateBasket(string uriArguement);
    }
}
