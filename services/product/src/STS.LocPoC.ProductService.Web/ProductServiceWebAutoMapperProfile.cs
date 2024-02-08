using AutoMapper;
using STS.LocPoC.ProductService.Products;

namespace STS.LocPoC.ProductService.Web;

public class ProductServiceWebAutoMapperProfile : Profile
{
    public ProductServiceWebAutoMapperProfile()
    {
        CreateMap<ProductDto, ProductUpdateDto>().MapExtraProperties();
    }
}
