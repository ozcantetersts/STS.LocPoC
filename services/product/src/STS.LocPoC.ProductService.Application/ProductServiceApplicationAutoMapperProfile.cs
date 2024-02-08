using AutoMapper;
using STS.LocPoC.ProductService.Products;

namespace STS.LocPoC.ProductService;

public class ProductServiceApplicationAutoMapperProfile : Profile
{
    public ProductServiceApplicationAutoMapperProfile()
    {
        CreateMap<Product, ProductDto>().MapExtraProperties();
    }
}
