namespace ProductSearchService.Domain;

public class Supermarket
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Product> Products { get; set; } = [];
    public List<SupermarketProduct> SupermarketProducts { get; set; } = [];

    /*
    public string ImageLogo { get; set; }
    public string ImageMiniLogo { get; set; }
    */
}
