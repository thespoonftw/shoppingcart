using System;

namespace ShoppingBasket {
    public class DatabaseReader {

        private static readonly Product[] Products = new[]
        {
            new Product() {
                ProductId = 0,
                Name = "Bread",
                Price = 110,
                ImageUrl = "https://images.pexels.com/photos/4775241/pexels-photo-4775241.jpeg"
            },
            new Product() {
                ProductId = 1,
                Name = "Milk",
                Price = 50,
                ImageUrl = "https://images.pexels.com/photos/7573152/pexels-photo-7573152.jpeg"
            },
            new Product() {
                ProductId = 2,
                Name = "Cheese",
                Price = 90,
                ImageUrl = "https://images.pexels.com/photos/10165775/pexels-photo-10165775.jpeg"
            },
            new Product() {
                ProductId = 3,
                Name = "Soup",
                Price = 60,
                ImageUrl = "https://images.pexels.com/photos/8743923/pexels-photo-8743923.jpeg"
            },
            new Product() {
                ProductId = 4,
                Name = "Butter",
                Price = 120,
                ImageUrl = "https://images.pexels.com/photos/5865461/pexels-photo-5865461.jpeg"
            },
        };

        public static Product[] GetAllProducts() {
            return Products;
        }

        public static Product GetProduct(int productId) {
            return Products[productId];
        }
    }
}
