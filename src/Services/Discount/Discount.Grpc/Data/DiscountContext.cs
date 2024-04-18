using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data;

public class DiscountContext : DbContext
{
    public DbSet<Coupon> Coupons { get; set; }
 
    public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coupon>().HasData(
            new Coupon { Id = 1, ProductName = "IPhoneX", ProductDescription = "Iphone Discount", Amount= 200 },
            new Coupon { Id = 2, ProductName = "Samsung 12", ProductDescription = "Samsung Discount", Amount= 100 }
        );        
    }
}
