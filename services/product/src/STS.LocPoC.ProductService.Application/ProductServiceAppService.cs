using STS.LocPoC.ProductService.Localization;
using Volo.Abp.Application.Services;

namespace STS.LocPoC.ProductService;

public abstract class ProductServiceAppService : ApplicationService
{
    protected ProductServiceAppService()
    {
        LocalizationResource = typeof(ProductServiceResource);
        ObjectMapperContext = typeof(ProductServiceApplicationModule);
    }
}
