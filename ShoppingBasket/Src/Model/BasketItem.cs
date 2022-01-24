using System;

namespace ShoppingBasket 
{
    /// <summary>
    /// One item in a basket. Could be a discount or a product.
    /// </summary>
    public class BasketItem 
    {
        public int Amount { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string PriceString => Price.ToPriceString();

        public int SumPrice => Price * Amount;

        public string SumPriceString => SumPrice.ToPriceString();

    }
}
