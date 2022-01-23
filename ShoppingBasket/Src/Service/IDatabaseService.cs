using System;

namespace ShoppingBasket 
{
    public interface IDatabaseService 
    {
        public Product[] GetAllProducts();
        public Product GetProduct(int productId);
    }
}
