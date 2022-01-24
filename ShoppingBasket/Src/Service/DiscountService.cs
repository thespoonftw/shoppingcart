using System;
using System.Collections.Generic;

namespace ShoppingBasket
{
    public class DiscountService : IDiscountService
    {
        IDatabaseService databaseService;

        public DiscountService(IDatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        public BasketItem[] GetDiscounts(Dictionary<int, int> basketDictionary)
        {
            if (basketDictionary == null) return Array.Empty<BasketItem>();
            var discounter = new Discounter(basketDictionary, databaseService);
            // ideally these discounts will be read from a config or database
            discounter.ApplyOneThirdDiscount(4);
            discounter.ApplyBogofDiscount(2);
            discounter.ApplyComboDiscount(3, 0);
            return discounter.Discounts.ToArray();
        }

        private class Discounter
        {
            public List<BasketItem> Discounts { get; private set; }

            private Dictionary<int, int> basketDictionary;
            private IDatabaseService databaseService;

            public Discounter(Dictionary<int, int> basketDictionary, IDatabaseService databaseService)
            {
                this.basketDictionary = basketDictionary;
                this.databaseService = databaseService;
                Discounts = new List<BasketItem>();
            }

            // could add a parameter here to allow for different percentage discounts
            public void ApplyOneThirdDiscount(int productId)
            {
                if (!basketDictionary.ContainsKey(productId)) { return; }
                var product = databaseService.GetProduct(productId);
                Discounts.Add(
                    new BasketItem()
                    {
                        Amount = basketDictionary[productId],
                        Description = $"{product.Name} 1/3 off",
                        Price = product.Price / 3
                    }
                );
            }

            public void ApplyBogofDiscount(int productId)
            {
                if (!basketDictionary.ContainsKey(productId) || basketDictionary[productId] < 2) return;
                var product = databaseService.GetProduct(productId);
                Discounts.Add(
                    new BasketItem()
                    {
                        Amount = basketDictionary[productId] / 2,
                        Description = $"{product.Name} BOGOF",
                        Price = product.Price
                    }
                );
            }

            public void ApplyComboDiscount(int fullPriceId, int halfPriceId)
            {
                if (!basketDictionary.ContainsKey(fullPriceId) || !basketDictionary.ContainsKey(halfPriceId)) return;
                var fullPriceProduct = databaseService.GetProduct(fullPriceId);
                var halfPriceProduct = databaseService.GetProduct(halfPriceId);
                Discounts.Add(
                    new BasketItem()
                    {
                        Amount = Math.Min(basketDictionary[fullPriceId], basketDictionary[halfPriceId]),
                        Description = $"{fullPriceProduct.Name} and Half Price {halfPriceProduct.Name}",
                        Price = halfPriceProduct.Price / 2
                    }
                );
            }
        }
    }

    
}
