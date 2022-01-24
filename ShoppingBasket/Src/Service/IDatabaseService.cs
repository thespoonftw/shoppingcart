namespace ShoppingBasket
{
    public interface IDatabaseService 
    {
        /// <summary>
        /// Get all products in the database
        /// </summary>
        /// <returns>Array of all products</returns>
        public Product[] GetAllProducts();

        /// <summary>
        /// Get a particular item in the database
        /// </summary>
        /// <param name="productId">Id of product</param>
        /// <returns>Requested product. Null if invalid.</returns>
        public Product GetProduct(int productId);
    }
}
