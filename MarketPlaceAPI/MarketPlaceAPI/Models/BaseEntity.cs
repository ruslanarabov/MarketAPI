namespace MarketPlaceAPI.Models;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
}

public abstract class AuditableEntity : BaseEntity
{
    public DateTime CreatedAt { get; set; }
    public Guid? CreatedBy { get; set; }
}