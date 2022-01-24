using System;

namespace ShoppingBasket 
{
    public static class PriceHelper 
    {
        public static string ToPriceString(this int input) 
        {
            var pos = Math.Abs(input);
            var negative = input < 0 ? "-" : "";
            return $"{negative}£{pos / 100}.{pos % 100:00}";
        }
    }
}
