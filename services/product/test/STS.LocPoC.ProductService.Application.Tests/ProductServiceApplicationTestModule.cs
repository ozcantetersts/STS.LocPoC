using Volo.Abp.Modularity;

namespace STS.LocPoC.ProductService;

[DependsOn(
    typeof(ProductServiceApplicationModule),
    typeof(ProductServiceDomainTestModule)
    )]
public class ProductServiceApplicationTestModule : AbpModule
{

}
