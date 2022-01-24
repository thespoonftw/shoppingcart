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

        public string SubTotal { get; set; }

        public string Total { get; set; }
    }
}
