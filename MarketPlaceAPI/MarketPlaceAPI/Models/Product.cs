namespace MarketPlaceAPI.Models;

public class Product : AuditableEntity
{
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public Guid StoreId { get; set; }
    public Store Store { get; set; } = null!;
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ProductName)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.Price)
            .HasPrecision(18, 2)
            .IsRequired();

        builder.Property(x => x.StockQuantity)
            .IsRequired();

        builder.HasOne(x => x.Store)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.StoreId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.ProductName);
    }
}