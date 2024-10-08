using ElektroJohnAPI.Contexts;
using ElektroJohnAPI.Extensions;
using ElektroJohnAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ElektroJohnAPI.Repositories;

public class SalesRepository(ElektroJohnDb db) : ISalesRepository
{
    public async Task InsertSale(Sale sale)
    {
        db.Sales.Add(sale);
        await db.SaveChangesAsync();
    }

    public async Task<List<Sale>> GetSales(SalesFilter? filter)
    {
        var query = db.Sales.AsNoTracking();

        if (filter == null)
            return await query.ToListAsync();
        
        return await query
            .WhereIfNotNull(filter.To, x => x.Date <= filter.To)
            .WhereIfNotNull(filter.From, x => x.Date >= filter.From)
            .ToListAsync();
    }
}