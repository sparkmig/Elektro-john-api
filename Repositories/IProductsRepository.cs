using ElektroJohnAPI.Models;

namespace ElektroJohnAPI.Repositories;

public interface IProductsRepository
{
    Task InsertProducts(List<Product> products);
    Task<List<Product>> GetProducts();
    bool AnyProducts();
}