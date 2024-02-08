using STS.LocPoC.AdministrationService;
using STS.LocPoC.AdministrationService.EntityFrameworkCore;
using STS.LocPoC.IdentityService;
using STS.LocPoC.IdentityService.EntityFrameworkCore;
using STS.LocPoC.ProductService;
using STS.LocPoC.ProductService.EntityFrameworkCore;
using STS.LocPoC.SaasService;
using STS.LocPoC.SaasService.EntityFrameworkCore;
using STS.LocPoC.Shared.Hosting;
using Volo.Abp.Modularity;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using STS.LocPoC.LocationService;
using STS.LocPoC.LocationService.EntityFrameworkCore;

namespace STS.LocPoC.DbMigrator;

[DependsOn(
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(LocPoCSharedHostingModule),
    typeof(IdentityServiceEntityFrameworkCoreModule),
    typeof(IdentityServiceApplicationContractsModule),
    typeof(SaasServiceEntityFrameworkCoreModule),
    typeof(SaasServiceApplicationContractsModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(AdministrationServiceApplicationContractsModule),
    typeof(ProductServiceApplicationContractsModule),
    typeof(ProductServiceEntityFrameworkCoreModule),
     typeof(LocationServiceApplicationContractsModule),
    typeof(LocationServiceEntityFrameworkCoreModule)
)]
public class LocPoCDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDistributedCacheOptions>(options => { options.KeyPrefix = "LocPoC:"; });
    }
}
