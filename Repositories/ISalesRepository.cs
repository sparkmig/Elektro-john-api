using ElektroJohnAPI.Models;

namespace ElektroJohnAPI.Repositories;

public interface ISalesRepository
{
    Task InsertSale(Sale sale);
    Task<List<Sale>> GetSales(SalesFilter? filter);
}