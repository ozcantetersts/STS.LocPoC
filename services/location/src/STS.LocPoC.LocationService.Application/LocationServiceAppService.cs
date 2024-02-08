using STS.LocPoC.LocationService.Localization;
using Volo.Abp.Application.Services;

namespace STS.LocPoC.LocationService;

public abstract class LocationServiceAppService : ApplicationService
{
    protected LocationServiceAppService()
    {
        LocalizationResource = typeof(LocationServiceResource);
        ObjectMapperContext = typeof(LocationServiceApplicationModule);
    }
}
