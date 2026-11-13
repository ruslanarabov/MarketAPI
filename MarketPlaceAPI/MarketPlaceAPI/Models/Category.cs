namespace MarketPlaceAPI.Models;

public class Category : BaseEntity
{
    public string CategoryName { get; set; } = null!;
    public ICollection<Product> Products { get; set; } = new List<Product>();
}

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(c => c.CategoryName)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.HasIndex(c => c.CategoryName)
            .IsUnique();
    }
}