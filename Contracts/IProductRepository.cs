public interface IProductRepository
{
    
Task<bool> CreateProduct(Product product);

Task<IReadOnlyList<Product>> GetProducts(GetProductListQuery query);
Task<bool> UpdateProduct(Product product);
Task<Product?> GetProductById(string id);
}