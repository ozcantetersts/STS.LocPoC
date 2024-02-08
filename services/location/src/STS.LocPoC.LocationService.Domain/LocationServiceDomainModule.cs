using Volo.Abp.Domain;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace STS.LocPoC.LocationService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AbpCachingModule),
    typeof(LocationServiceDomainSharedModule)
)]
public class LocationServiceDomainModule : AbpModule
{
}
