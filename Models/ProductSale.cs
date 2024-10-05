using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElektroJohnAPI.Models;

public class ProductSale
{
    [Key]
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int SaleId { get; set; }
    public int Amount { get; set; }
    
    [ForeignKey("ProductId")]
    public Product? Product { get; set; }
}