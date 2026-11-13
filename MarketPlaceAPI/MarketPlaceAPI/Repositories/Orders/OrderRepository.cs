namespace MarketPlaceAPI.Repositories.Orders;

public class OrderRepository(AppDbContext context) : GenericRepository<Order>(context), IOrderRepository
{
    public Task<List<Order>> GetOrdersByBuyerAsync(Guid buyerId)
    {
        return context.Orders
            .AsNoTracking()
            .Where(x => x.BuyerId == buyerId)
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
    }

    public Task<Order?> GetOrderWithItemsAsync(Guid orderId)
    {
        return context.Orders
            .AsNoTracking()
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(x => x.Id == orderId);
    }
}