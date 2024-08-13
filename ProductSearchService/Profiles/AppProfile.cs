using AutoMapper;
using ProductSearchService.Domain;
using ProductSearchService.WebApi.Contract;

namespace ProductSearchService.WebApi.Profiles;

public class AppProfile : Profile
{
    public AppProfile()
    {
        CreateMap<Product, ProductWithDetailsResponse>();
        CreateMap<SupermarketProduct, ProductAtSupermarketResponse>()
            .ForMember(sp => sp.Supermarket, o => o.MapFrom(sp => sp.Supermarket.Name));
        CreateMap<SupermarketProduct, ProductAtSupermarketRequest>();
        CreateMap<Product, ProductResponse>();
        CreateMap<Supermarket, SupermarketResponse>();
        CreateMap<Supermarket, SupermarketWithDetailsResponse>();
        CreateMap<SupermarketProduct, SupermarketWithProductResponse>()
            .ForMember(sp => sp.Product, o => o.MapFrom(sp => sp.Product.Name));
    }
}
