using STS.LocPoC.LocationService.UserLocations;
using Xunit;

namespace STS.LocPoC.LocationService.EntityFrameworkCore.Applications.UserLocations;

public class EfCoreUserLocationsAppServiceTests : UserLocationsAppServiceTests<LocationServiceEntityFrameworkCoreTestModule>
{
}