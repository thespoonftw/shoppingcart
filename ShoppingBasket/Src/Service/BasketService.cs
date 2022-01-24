using ShoppingBasket.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasket 
{
    public class BasketService : IBasketService
    {
        IDatabaseService databaseService;
        IDiscountService discountService;

        public BasketService(IDatabaseService databaseService, IDiscountService discountService)
        {
            this.databaseService = databaseService;
            this.discountService = discountService;
        }

        public Basket CalculateBasket(Dictionary<int, int> basketItems)
        {            
            var products = GetBasketProducts(basketItems);
            var subTotal = GetSubtotal(products);
            var discounts = discountService.GetDiscounts(basketItems);
            var total = GetTotal(subTotal, discounts);

            return new Basket()
            {
                Total = total.ToPriceString(),
                SubTotal = subTotal.ToPriceString(),
                Products = products,
                Discounts = discounts,
            };
        }      

        private BasketItem[] GetBasketProducts(Dictionary<int, int> basketDictionary)
        {
            var productList = new List<BasketItem>();
            foreach (var pair in basketDictionary)
            {
                var product = databaseService.GetProduct(pair.Key);
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
