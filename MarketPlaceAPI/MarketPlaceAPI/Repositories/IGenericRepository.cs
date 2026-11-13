namespace MarketPlaceAPI.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{   
    Task<T?> GetByIdAsync(Guid id);
    Task<List<T>> GetAllAsync();
    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
    Task<int> SaveChangesAsync();
}