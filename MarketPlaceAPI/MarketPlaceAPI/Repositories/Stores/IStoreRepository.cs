namespace MarketPlaceAPI.Repositories.Stores;

public interface IStoreRepository : IGenericRepository<Store>
{
    Task<List<Store>> GetStoresBySellerAsync(Guid sellerId);
    Task<Store?> GetStoreWithProductsAsync(Guid storeId);
}