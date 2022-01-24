using System;
using System.Collections.Generic;

namespace ShoppingBasket 
{
    public static class UriConverter 
    {
        /// <summary>
        /// Creates a populated dictionary from a URI basket string.
        /// </summary>
        /// <param name="basketString">Basket contents in form of string. Items seperated by _ and amounts seperated by -</param>
        /// <returns>Dictionary where key is product ID and value is quantity of product</returns>
        public static Dictionary<int, int> BasketStringToDictionary(string basketString) 
        {
            var returner = new Dictionary<int, int>();
            var split = basketString.Split('_', StringSplitOptions.RemoveEmptyEntries);
            foreach (var s in split)
            {
                var pair = s.Split('-');
                var product = int.Parse(pair[0]);
                var amount = int.Parse(pair[1]);
                returner.Add(product, amount);
            }
            return returner;
        }
    }
}
