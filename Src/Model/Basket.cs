using ShoppingBasket.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket 
{
    public class Basket
    {
        public BasketItem[] Products { get; set; }

        public BasketItem[] Discounts { get; set; }

        public string SubTotal { get; set; }

        public string Total { get; set; }
    }
}
