using System;

namespace ShoppingBasket 
{
    public static class PriceHelper 
    {
        /// <summary>
        /// Converts integer price to displayable string price.
        /// </summary>
        /// <param name="input">Price in pence</param>
        /// <returns>Price in string with £ and decimal</returns>
        public static string ToPriceString(this int input) 
        {
            var pos = Math.Abs(input);
            var negative = input < 0 ? "-" : "";
            return $"{negative}£{pos / 100}.{pos % 100:00}";
        }
    }
}
