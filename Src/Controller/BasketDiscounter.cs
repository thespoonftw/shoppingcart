using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingBasket.Controllers 
{
    public class BasketDiscounter 
    {
        private Dictionary<int, int> basketDictionary;
        private List<BasketItem> discounts = new List<BasketItem>();
        private DatabaseReader databaseReader = new DatabaseReader();

        public BasketDiscounter(Dictionary<int, int> basketDictionary) 
        {
            this.basketDictionary = basketDictionary;
        }

        // could add a parameter here to allow for different percentage discounts
        public void ApplyPercentageDiscount(int productId) 
        {
            if (!basketDictionary.ContainsKey(productId)) { return; }
            var product = databaseReader.GetProduct(productId);
            discounts.Add(
                new BasketItem() {
                    Amount = basketDictionary[productId],
                    Description = $"{product.Name} 1/3 off",
                    Price = product.Price / 3
                }
            );
        }

        public void ApplyBogofDiscount(int productId) 
        {
            if (!basketDictionary.ContainsKey(productId) || basketDictionary[productId] < 2) return;
            var product = databaseReader.GetProduct(productId);
            discounts.Add(
                new BasketItem() {
                    Amount = basketDictionary[productId] / 2,
                    Description = $"{product.Name} BOGOF",
                    Price = product.Price
                }
            );
        }

        public void ApplyComboDiscount(int fullPriceId, int halfPriceId) 
        {
            if (!basketDictionary.ContainsKey(fullPriceId) || !basketDictionary.ContainsKey(halfPriceId)) return;
            var fullPriceProduct = databaseReader.GetProduct(fullPriceId);
            var halfPriceProduct = databaseReader.GetProduct(halfPriceId);
            discounts.Add(
                new BasketItem() 
                {
                    Amount = Math.Min(basketDictionary[fullPriceId], basketDictionary[halfPriceId]),
                    Description = $"{fullPriceProduct.Name} and Half Price {halfPriceProduct.Name}",
                    Price = halfPriceProduct.Price / 2
                }
            );
        }

        public BasketItem[] GetDiscounts() 
        {
            return discounts.ToArray();
        }        
    }
}
