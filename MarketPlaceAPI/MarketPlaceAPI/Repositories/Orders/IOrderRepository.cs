namespace MarketPlaceAPI.Repositories.Orders;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<List<Order>> GetOrdersByBuyerAsync(Guid buyerId);
    Task<Order?> GetOrderWithItemsAsync(Guid orderId);
}