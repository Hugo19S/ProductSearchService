using System.ComponentModel.DataAnnotations;

namespace ProductSearchService.WebApi.Contract;

public class CreateSupermarketRequest
{
    public string? Name { get; set; }
}

public class SupermarketResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
