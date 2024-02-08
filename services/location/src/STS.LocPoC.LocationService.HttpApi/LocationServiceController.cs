using STS.LocPoC.LocationService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace STS.LocPoC.LocationService;

public abstract class LocationServiceController : AbpControllerBase
{
    protected LocationServiceController()
    {
        LocalizationResource = typeof(LocationServiceResource);
    }
}
