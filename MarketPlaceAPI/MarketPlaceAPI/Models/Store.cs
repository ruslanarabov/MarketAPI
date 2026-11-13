namespace MarketPlaceAPI.Models;

public class Store : AuditableEntity
{
    public string StoreName { get; set; } = null!;
    public User Seller { get; set; } = null!;
    public Guid SellerId { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
}

public class StoreConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.StoreName)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.HasOne(x => x.Seller)
            .WithMany(x => x.Stores)
            .HasForeignKey(x => x.SellerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}