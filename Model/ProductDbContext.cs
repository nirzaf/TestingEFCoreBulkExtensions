using Bogus;

using Microsoft.EntityFrameworkCore;

namespace TestingEFCoreBulkExtensions.Model;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasKey(p => p.Id);

        var products = new Faker<Product>()
            .RuleFor(p => p.Id, f => Guid.NewGuid())
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
            .Generate(10);
        modelBuilder.Entity<Product>().HasData(products);
        base.OnModelCreating(modelBuilder);
    }
}