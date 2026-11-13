namespace MarketPlaceAPI.Repositories.Products;

public class ProductRepository(AppDbContext context)
    : GenericRepository<Product>(context), IProductRepository
{
    public async Task<List<Product>> SearchProductsAsync(
        string? name,
        Guid? categoryId,
        decimal? minPrice,
        decimal? maxPrice)
    {
        var query = context.Products.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(x => x.ProductName.ToLower().Contains(name.ToLower()));

        if (categoryId.HasValue)
            query = query.Where(x => x.CategoryId == categoryId.Value);

        if (minPrice.HasValue)
            query = query.Where(x => x.Price >= minPrice.Value);

        if (maxPrice.HasValue)
            query = query.Where(x => x.Price <= maxPrice.Value);

        return await query.ToListAsync();
    }

    public Task<List<Product>> GetProductsByStoreAsync(Guid storeId)
    {
        return context.Products
            .AsNoTracking()
            .Where(x => x.StoreId == storeId)
            .ToListAsync();
    }
}