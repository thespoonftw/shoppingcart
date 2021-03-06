using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ShoppingBasket
{
    public class BasketService : IBasketService
    {
        private IDatabaseService databaseService;
        private IDiscountService discountService;

        public BasketService(IDatabaseService databaseService, IDiscountService discountService)
        {
            this.databaseService = databaseService;
            this.discountService = discountService;
        }

        public Basket CalculateBasket(string basketString)
        {
            var basketItems = BasketStringToDictionary(basketString);
            var products = GetBasketProducts(basketItems);
            var subTotal = GetSubtotal(products);
            var discounts = discountService.GetDiscounts(basketItems);
            var total = GetTotal(subTotal, discounts);

            return new Basket()
            {
                Total = total,
                SubTotal = subTotal,
                Products = products,
                Discounts = discounts,
            };
        }

        private Dictionary<int, int> BasketStringToDictionary(string basketString)
        {
            if (basketString == null) throw new ArgumentException("Null Input");
            if (!Regex.IsMatch(basketString, @"^[0-9_x]*$")) throw new ArgumentException("Invalid Characters");

            try
            {
                var returner = new Dictionary<int, int>();
                if (basketString == "" || basketString == null)
                {
                    return returner;
                }

                var split = basketString.Split('_');
                foreach (var s in split)
                {
                    var pair = s.Split('x');
                    var amount = int.Parse(pair[0]);
                    var product = int.Parse(pair[1]);
                    returner.Add(product, amount);
                }
                return returner;
            }
            catch
            {
                throw new ArgumentException("Invalid Syntax");
            }

        }

        private BasketItem[] GetBasketProducts(Dictionary<int, int> basketDictionary)
        {
            var productList = new List<BasketItem>();
            foreach (var pair in basketDictionary)
            {
                var product = databaseService.GetProduct(pair.Key);
                if (product == null) continue;
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

        private int GetTotal(int subtotal, BasketItem[] discounts)
        {
            return subtotal - discounts.Sum(d => d.SumPrice);
        }
    }

}
