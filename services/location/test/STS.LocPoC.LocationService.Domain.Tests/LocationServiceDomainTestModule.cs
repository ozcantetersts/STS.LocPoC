using STS.LocPoC.LocationService.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace STS.LocPoC.LocationService;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(LocationServiceEntityFrameworkCoreTestModule)
    )]
public class LocationServiceDomainTestModule : AbpModule
{

}
