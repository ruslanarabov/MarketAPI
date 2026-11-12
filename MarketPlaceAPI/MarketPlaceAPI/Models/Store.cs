namespace MarketPlaceAPI.Models;

public class Store : AuditableEntity
{
    public string StoreName { get; set; } = null!;
    public User Seller { get; set; } = null!;
    public Guid SellerId { get; set; }
}