using AutoMapper;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductSearchService.Application.Supermarkets.Commands.CreateSupermarket;
using ProductSearchService.Application.Supermarkets.Commands.DeleteSupermarket;
using ProductSearchService.Application.Supermarkets.Commands.UpdateSupermarket;
using ProductSearchService.Application.Supermarkets.Queries.GetSupermarket;
using ProductSearchService.Application.Supermarkets.Queries.GetSupermarkets;
using ProductSearchService.Domain;
using ProductSearchService.WebApi.Contract;

namespace ProductSearchService.WebApi.Controllers
{
    [Route("[controller]")]
    public class SupermarketController(
        ISender sender,
        IMapper _mapper) : ApiController
    {

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetSupermarket(Guid id, CancellationToken ct)
        {
            ErrorOr<Supermarket> supermarketOr = await sender.Send(new GetSupermarketQuery(id), ct);

            return supermarketOr.Match<ActionResult>(
                v => Ok(_mapper.Map<SupermarketWithDetailsResponse>(v)), 
                NotFound);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetSupermarkets(CancellationToken ct)
        {
            var products = await sender.Send(new GetSupermarketsQuery(), ct);

            return products.Match<ActionResult>(
                v => Ok(_mapper.Map<IEnumerable<SupermarketResponse>>(v)),
                NotFound);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(CreateSupermarketRequest supermarket, CancellationToken ct)
        {
            var supermarketCreated = await sender.Send(new CreateSupermarketCommand(supermarket.Name), ct);

            return supermarketCreated.Match<ActionResult>(
                v => CreatedAtAction(nameof(GetSupermarket), new
                {
                    id = v.Id,
                }, _mapper.Map<SupermarketResponse>(v)),
                Problem);
        }

        [HttpPut("{supermarketId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update(Guid supermarketId, CreateSupermarketRequest supermarket, CancellationToken ct)
        {
            var supermarketUpdatedOr = await sender.Send(new UpdateSupermarketCommand(supermarketId, supermarket.Name), ct);

            return supermarketUpdatedOr.Match<ActionResult>(
                v => Ok(_mapper.Map<SupermarketResponse>(v)),
                NotFound);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid id, CancellationToken ct)
        {
            var supermarketDeletedOr = await sender.Send(new DeleteSupermarketCommand(id), ct);

            return supermarketDeletedOr.Match<ActionResult>(
                v => Ok($"Supermarket with id {v} was deleted."),
                NotFound);
        }
    }
}
