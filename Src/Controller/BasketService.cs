using ShoppingBasket.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket 
{
    public class BasketService
    {
        public Basket CalculateBasket(string uriCode)
        {            
            var dict = FillDictionary(uriCode);
            var products = GetBasketProducts(dict);
            var subTotal = GetSubtotal(products);
            var discounts = GetBasketDiscounts(dict);
            var total = GetTotal(subTotal, discounts);

            return new Basket()
            {
                Total = total.ToPriceString(),
                SubTotal = subTotal.ToPriceString(),
                Products = products,
                Discounts = discounts,
            };
        }

        private Dictionary<int, int> FillDictionary(string uriCode)
        {
            var returner = new Dictionary<int, int>();
            var split = uriCode.Split('_');
            foreach (var s in split)
            {
                var pair = s.Split('-');
                var product = int.Parse(pair[0]);
                var amount = int.Parse(pair[1]);
                returner.Add(product, amount);
            }
            return returner;
        }        

        private BasketItem[] GetBasketProducts(Dictionary<int, int> basketDictionary)
        {
            var productList = new List<BasketItem>();
            var database = new DatabaseReader();
            foreach (var pair in basketDictionary)
            {
                var product = database.GetProduct(pair.Key);
                productList.Add(
                    new BasketItem()
                    {
                        Amount = pair.Value,
                        Description = product.Name,
                        Price = product.Price
                    }
                );
            }
            return productList.ToArray();
        }

        private int GetSubtotal(BasketItem[] products)
        {
            return products.Sum(p => p.SumPrice);
        }

        private BasketItem[] GetBasketDiscounts(Dictionary<int, int> basketDictionary)
        {
            var discounter = new BasketDiscounter(basketDictionary);
            // ideally configure these from the database model
            discounter.ApplyPercentageDiscount(4);
            discounter.ApplyBogofDiscount(2);
            discounter.ApplyComboDiscount(3, 0);
            return discounter.GetDiscounts();
        }

        private int GetTotal(int subtotal, BasketItem[] discounts)
        {
            return subtotal - discounts.Sum(d => d.SumPrice);
        }
    }
}
