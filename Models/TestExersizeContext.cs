using Microsoft.EntityFrameworkCore;

namespace TestExersize.Models;

public class TestExersizeContext : DbContext
{
    public TestExersizeContext(DbContextOptions<TestExersizeContext> options)
        : base(options)
    {
    }

    public DbSet<Material> MaterialItems { get; set; } = null!;
    public DbSet<Seller> SellerItems { get; set; } = null!;
}