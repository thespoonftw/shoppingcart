using System;

namespace ShoppingBasket 
{
    /// <summary>
    /// A product as shown in the shop, stored in database.
    /// </summary>
    public class Product 
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public string PriceString => Price.ToPriceString();

        public string ImageUrl { get; set; }
    }
}
