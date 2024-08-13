using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSearchService.Domain;


public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Barcode { get; set; }
    public string? Image { get; set; }
    public List<Supermarket> Supermarkets { get; } = [];
    public List<SupermarketProduct> SupermarketProducts { get; } = [];
}

