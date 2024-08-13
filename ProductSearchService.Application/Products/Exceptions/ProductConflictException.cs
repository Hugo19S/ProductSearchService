namespace ProductSearchService.Application.Products.Exceptions;

public class ProductConflictException(string name) : Exception($"O produto com o nome {name} já existe.");
