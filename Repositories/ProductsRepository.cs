using ElektroJohnAPI.Contexts;
using ElektroJohnAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ElektroJohnAPI.Repositories;

public class ProductsRepository(ElektroJohnDb db) : IProductsRepository
{
    public async Task InsertProducts(List<Product> products)
    {
        db.Products.AddRange(products);
        await db.SaveChangesAsync();
    }

    public async Task<List<Product>> GetProducts()
    {
        return await db.Products.ToListAsync();
    }

    public bool AnyProducts()
    {
        return db.Products.Any();
    }
}