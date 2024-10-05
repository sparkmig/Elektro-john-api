using System.ComponentModel.DataAnnotations;

namespace ElektroJohnAPI.Models;

public class Product(string name, float price)
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = name;
    public float Price { get; set; } = price;
}