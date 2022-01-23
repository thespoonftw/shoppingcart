using System;

namespace ShoppingBasket 
{
    public static class PriceHelper 
    {
        public static string ToPriceString(this int input) 
        {
            return $"£{input / 100}.{(input % 100).ToString("00")}";
        }
    }
}
