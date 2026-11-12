namespace MarketPlaceAPI.Models;

public class User : AuditableEntity
{
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public UserRole Role { get; set; }
    public ICollection<Store> Stores { get; set; } = new List<Store>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
public enum UserRole : byte
{
    Buyer = 1,
    Seller = 2,
    Admin = 3
}