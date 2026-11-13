namespace MarketPlaceAPI.Repositories.Products;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<List<Product>> SearchProductsAsync(
        string? name,
        Guid? categoryId,
        decimal? minPrice,
        decimal? maxPrice);

    Task<List<Product>> GetProductsByStoreAsync(Guid storeId);
}