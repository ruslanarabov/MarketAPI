namespace MarketPlaceAPI.Repositories.Stores;

public class StoreRepository(AppDbContext context) : GenericRepository<Store>(context), IStoreRepository
{
    public Task<List<Store>> GetStoresBySellerAsync(Guid sellerId)
    {
        return context.Stores
            .AsNoTracking()
            .Where(x => x.SellerId == sellerId)
            .ToListAsync();
    }

    public Task<Store?> GetStoreWithProductsAsync(Guid storeId)
    {
        return context.Stores
            .AsNoTracking()
            .Include(x => x.Products)
            .FirstOrDefaultAsync(x => x.Id == storeId);
    }
}