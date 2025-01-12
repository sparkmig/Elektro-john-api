using ElektroJohnAPI.Contexts;
using ElektroJohnAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ElektroJohnAPI;

public static class DependencyInjection
{
    public static void Configure(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ElektroJohnDb>(opt => opt.UseInMemoryDatabase("ElektroJohn"));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        builder.Services.AddTransient<IProductsRepository, ProductsRepository>();
        builder.Services.AddTransient<ISalesRepository, SalesRepository>();
    }
}