using Volo.Abp.Modularity;

namespace STS.LocPoC.LocationService;

[DependsOn(
    typeof(LocationServiceApplicationModule),
    typeof(LocationServiceDomainTestModule)
    )]
public class LocationServiceApplicationTestModule : AbpModule
{

}
