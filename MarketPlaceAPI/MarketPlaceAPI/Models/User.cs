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

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FullName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.Property(x => x.Password)
            .IsRequired();

        builder.Property(x => x.Role)
            .HasConversion<byte>()
            .IsRequired();
    }
}