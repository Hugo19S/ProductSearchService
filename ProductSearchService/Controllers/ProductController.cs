using AutoMapper;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductSearchService.Application.Products.Commands.CreateProducts;
using ProductSearchService.Application.Products.Commands.DeleteProducts;
using ProductSearchService.Application.Products.Commands.UpdateProducts;
using ProductSearchService.Application.Products.Queries.GetProduct;
using ProductSearchService.Application.Products.Queries.GetProducts;
using ProductSearchService.Application.SendMessages;
using ProductSearchService.Domain;
using ProductSearchService.WebApi.Contract;

namespace ProductSearchService.WebApi.Controllers;

[Route("[controller]")]
public class ProductController(
    ISender sender,
    IMapper _mapper) : ApiController
{

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetProduct(Guid id, CancellationToken ct)
    {
        ErrorOr<Product> productOr = await sender.Send(new GetProductQuery(id), ct);

        return productOr.Match<ActionResult>(v => Ok(_mapper.Map<ProductWithDetailsResponse>(v)), Problem);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetProducts(CancellationToken ct)
    {

        var products = await sender.Send(new GetProductsQuery(), ct);

        return products.Match<ActionResult>(
            v => Ok(_mapper.Map<IEnumerable<ProductResponse>>(v)), Problem);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> Create([FromBody] CreateProductRequest product, CancellationToken ct)
    {
        var productCreated = await sender.Send(new CreateProductCommand(product.Name, product.Barcode, product.Image), ct);

        return productCreated.Match(
            v => CreatedAtAction(nameof(GetProduct), new
            {
                id = v.Id
            }, _mapper.Map<ProductResponse>(v)), 
            Problem);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update(Guid id, UpdateProductRequest product, CancellationToken ct)
    {
        var productUpdatedOr = await sender.Send(new UpdateProductCommand(id, product.Name, product.Barcode, product.Image), ct);

        return productUpdatedOr.Match(
            v => Ok(_mapper.Map<ProductResponse>(v)), Problem);
    }


    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(Guid id, CancellationToken ct)
    {
        var productDeletedOr = await sender.Send(new DeleteProductCommand(id), ct);

        return productDeletedOr.Match(
            v => Ok($"The product with id {v} has been deleted."), Problem);
    }
}