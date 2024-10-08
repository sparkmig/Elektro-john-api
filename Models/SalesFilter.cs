using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;

namespace ElektroJohnAPI.Models;

public class SalesFilter
{
    public DateTime? To { get; set; }
    public DateTime? From { get; set; }
    
}