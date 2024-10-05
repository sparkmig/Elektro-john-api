using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElektroJohnAPI.Models;

public class Sale
{
    [Key]
    public int Id { get; set; }
    public float Sum { get; set; }
    public string Customer { get; set; }
    public DateTime Date { get; set; }
    
    [ForeignKey("SaleId")]
    public List<ProductSale>? Products { get; set; }
}