using ShoppingBasket.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket 
{
    /// <summary>
    /// Data structure for a basket as displayed on the user's screen when they proceed to checkout.
    /// </summary>
    public class Basket
    {
        public BasketItem[] Products { get; set; }

        public BasketItem[] Discounts { get; set; }

        public int SubTotal { get; set; }

        public string SubTotalString => SubTotal.ToPriceString();

        public int Total { get; set; }

        public string TotalString => Total.ToPriceString();
    }
}
