using AutoMapper;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductSearchService.Application.SupermarketProducts.Commands.CreateSupermarketProduct;
using ProductSearchService.Application.SupermarketProducts.Commands.DeleteSupermarketProduct;
using ProductSearchService.Application.SupermarketProducts.Commands.UpdateSupermarketProduct;
using ProductSearchService.Application.SupermarketProducts.Queries.GetSupermarketProduct;
using ProductSearchService.Application.SupermarketProducts.Queries.GetSupermarketsProducts;
using ProductSearchService.Domain;
using ProductSearchService.WebApi.Contract;

namespace ProductSearchService.WebApi.Controllers;

[Route("supermarket/product")]
public class SupermarketProductController(ISender sender, IMapper _mapper) : ApiController
{

    [HttpGet("{supermarketId:guid}/{productId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetSupermarketProduct(
        Guid supermarketId, Guid productId, CancellationToken ct)
    {
        ErrorOr<SupermarketProduct> supermarketProductOr = await sender.Send(new GetSupermarketProductQuery(supermarketId, productId), ct);

        return supermarketProductOr.Match<ActionResult>(Ok, e => NotFound());
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetSupermarketsProducts(CancellationToken ct)
    {
        var products = await sender.Send(new GetSupermarketsProductsQuerry(), ct);
        return Ok(products);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Create(
        ProductAtSupermarketRequest supermarketProduct, CancellationToken ct)
    {

        var supermarketProductCreatedOr = await sender.Send(new CreateSupermarketProductCommand(supermarketProduct.SupermarketId,
                                                                                                supermarketProduct.ProductId,
                                                                                                supermarketProduct.ProductQuantity,
                                                                                                supermarketProduct.Price,
                                                                                                supermarketProduct.Description), ct);

        return supermarketProductCreatedOr.Match<ActionResult>(
            v => CreatedAtAction(nameof(GetSupermarketProduct), new
            {
                supermarketId = supermarketProduct.SupermarketId,
                productId = supermarketProduct.ProductId
            }, _mapper.Map<ProductAtSupermarketRequest>(v)),
            NotFound);
    }

    [HttpDelete("{supermarketId:guid}/{productId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(Guid supermarketId, Guid productId, CancellationToken ct)
    {
        var deletedOr = await sender.Send(new DeleteSupermarketProductCommand(supermarketId, productId), ct);

        return deletedOr.Match<ActionResult>(
                   v => Ok($"SupermarketProduct with supermarketId {v.Item1} and productId {v.Item2} was deleted."),
                   NotFound);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update(
        ProductAtSupermarketRequest supermarketProduct, CancellationToken ct)
    {
        var supermarketProductUpdatedOr = await sender.Send(
            new UpdateSupermarketProductCommand(
                supermarketProduct.SupermarketId,
                supermarketProduct.ProductId,
                supermarketProduct.Price,
                supermarketProduct.ProductQuantity,
                supermarketProduct.Description
                ), ct);

        return supermarketProductUpdatedOr.Match<ActionResult>(
            v => Ok(_mapper.Map<ProductAtSupermarketResponse>(v)), 
            NotFound);
    }
}
