using STS.LocPoC.ProductService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace STS.LocPoC.ProductService;

public abstract class ProductServiceController : AbpController
{
    protected ProductServiceController()
    {
        LocalizationResource = typeof(ProductServiceResource);
    }
}
