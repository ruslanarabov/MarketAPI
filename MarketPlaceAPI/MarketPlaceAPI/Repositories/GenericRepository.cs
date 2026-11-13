namespace MarketPlaceAPI.Repositories;

public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : BaseEntity
{
    protected DbSet<T> Table => context.Set<T>();
    
    public async Task<T?> GetByIdAsync(Guid id) =>
        await Table.FindAsync([id]);

    public Task<List<T>> GetAllAsync() =>
        Table.AsNoTracking().ToListAsync();

    public async Task AddAsync(T entity) =>
        await Table.AddAsync(entity);

    public void Update(T entity) => Table.Update(entity);

    public void Remove(T entity) => Table.Remove(entity);

    public Task<int> SaveChangesAsync() => context.SaveChangesAsync();
}