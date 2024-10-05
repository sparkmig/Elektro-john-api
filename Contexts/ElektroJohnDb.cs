using ElektroJohnAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ElektroJohnAPI.Contexts;

public class ElektroJohnDb : DbContext
{
    public ElektroJohnDb(DbContextOptions<ElektroJohnDb> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<ProductSale> ProductSales { get; set; }
}