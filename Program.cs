
using System.Text.Json;
using ElektroJohnAPI;
using ElektroJohnAPI.Contexts;
using ElektroJohnAPI.Models;
using ElektroJohnAPI.Repositories;
using ElektroJohnAPI.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using CorsPolicy = ElektroJohnAPI.CorsPolicy;

var builder = WebApplication.CreateBuilder(args);

CorsPolicy.Configure(builder);
DependencyInjection.Configure(builder);

var app = builder.Build();

app.UseCors(CorsPolicy.PolicyName);

app.MapGet("/", async (IProductsRepository productsRepository) =>
{
    if(productsRepository.AnyProducts())
        return "Products already created";

    var products = JsonFileReader.ReadFromFile<List<Product>>("./products.json");
    
    if(products == null)
        return "Products is null";
    
    await productsRepository.InsertProducts(products);
    return "Products created";
});

app.MapGet("/sales", async ([AsParameters] SalesFilter filter, ISalesRepository salesRepository) =>
{
    if (filter.To.HasValue)
    {
        filter.To = filter.To.Value.AddDays(1);
    }
    return await salesRepository.GetSales(filter);
});

app.MapPost("/sales", async (Sale sale, ISalesRepository salesRepository) =>
{
    sale.Date = DateTime.Now;
    await salesRepository.InsertSale(sale);
});

app.MapGet("/products", async (IProductsRepository productsRepository) =>
{
    return await productsRepository.GetProducts();
});


app.Run();