using System;

namespace ShoppingBasket 
{
    public interface IDatabaseReader 
    {
        public Product[] GetAllProducts();
        public Product GetProduct(int productId);
    }
}
