
using System.Text.Json;
using ElektroJohnAPI;
using ElektroJohnAPI.Contexts;
using ElektroJohnAPI.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using CorsPolicy = ElektroJohnAPI.CorsPolicy;

var builder = WebApplication.CreateBuilder(args);

CorsPolicy.Configure(builder);
DependencyInjection.Configure(builder);

var app = builder.Build();

app.UseCors(CorsPolicy.PolicyName);
app.MapGet("/", async (ElektroJohnDb db) =>
{
    if(db.Products.Any())
        return "Products already created";
    
    string file = File.ReadAllText("./products.json");
    List<Product>? products = JsonSerializer.Deserialize<List<Product>>(file);
    
    if(products == null)
        return "Products is null";
    
    db.Products.AddRange(products);
    await db.SaveChangesAsync();
    return "Products created";
});

app.MapGet("/sales", async (ElektroJohnDb db) =>
{
    return db.Sales.ToList();
});

app.MapPost("/sales", async (Sale sale, ElektroJohnDb db) =>
{
    sale.Date = DateTime.Now;
    db.Sales.Add(sale);
    await db.SaveChangesAsync();
});

app.MapGet("/products", async (ElektroJohnDb db) =>
{
    return db.Products.ToList();
});


app.Run();