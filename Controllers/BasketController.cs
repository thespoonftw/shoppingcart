using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingBasket.Controllers {
    [ApiController]
    public class BasketController : ControllerBase {

        private readonly ILogger<BasketController> _logger;

        public BasketController(ILogger<BasketController> logger) {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public Basket Get(string id) {
            var itemDict = StringToDict(id);
            var returner = new Basket();
            returner.Items = GetItemStrings(itemDict);
            var subtotal = GetSubtotal(itemDict);
            returner.SubTotal = subtotal.ToPriceString();
            var discounts = GetDiscounts(itemDict);
            returner.Discounts = discounts.Select(s => s.Item1).ToArray();
            returner.Total = GetTotal(subtotal, discounts).ToPriceString();
            return returner;
        }

        private Dictionary<Product, int> StringToDict(string id) {
            var returner = new Dictionary<Product, int>();
            var split = id.Split('_');
            foreach (var s in split) {
                var pair = s.Split('-');
                var product = DatabaseReader.GetProduct(int.Parse(pair[0]));
                var amount = int.Parse(pair[1]);
                returner.Add(product, amount);
            }
            return returner;
        }

        private string[] GetItemStrings(Dictionary<Product, int> dict) {
            var returner = new List<string>();
            foreach (var pair in dict) {
                returner.Add(
                    $"{pair.Value}x {pair.Key.Name} {pair.Key.PriceString}"
                );
            }
            return returner.ToArray();
        }

        private int GetSubtotal(Dictionary<Product, int> dict) {
            var sum = 0;
            foreach (var pair in dict) {
                sum += pair.Key.Price * pair.Value;
            }
            return sum;
        }

        private List<(string, int)> GetDiscounts(Dictionary<Product, int> dict) {
            var returner = new List<(string, int)>();

            var butter = DatabaseReader.GetProduct(4);
            if (dict.ContainsKey(butter)) {
                var count = dict[butter];
                var saving = count * (butter.Price / 3);
                var desc = $"{count}x Butter 1/3 off -{saving.ToPriceString()}";
                returner.Add((desc, saving));
            }

            var cheese = DatabaseReader.GetProduct(2);
            if (dict.ContainsKey(cheese) && dict[cheese] >= 2) {
                var count = dict[cheese] / 2;
                var saving = count * cheese.Price;
                var desc = $"{count}x Cheese BOGOF -{saving.ToPriceString()}";
                returner.Add((desc, saving));
            }

            var soup = DatabaseReader.GetProduct(3);
            var bread = DatabaseReader.GetProduct(0);
            if (dict.ContainsKey(bread) && dict.ContainsKey(soup)) {
                var count = Math.Min(dict[bread], dict[soup]);
                var saving = count * (bread.Price / 2);
                var desc = $"{count}x Soup and Half Price Bread -{saving.ToPriceString()}";
                returner.Add((desc, saving));
            }            

            return returner;
        }

        private int GetTotal(int total, List<(string, int)> discounts) {
            var discountSum = 0;
            foreach (var pair in discounts) {
                discountSum += pair.Item2;
            }
            return total - discountSum;
        }
    }
}
