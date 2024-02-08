using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace STS.LocPoC.LocationService;

[DependsOn(
    typeof(LocationServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class LocationServiceApplicationContractsModule : AbpModule
{

}
