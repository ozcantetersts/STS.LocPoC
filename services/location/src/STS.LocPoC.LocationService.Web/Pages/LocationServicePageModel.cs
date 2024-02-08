using STS.LocPoC.LocationService.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace STS.LocPoC.LocationService.Web.Pages;

/* Inherit your PageModel classes from this class. */
public abstract class LocationServicePageModel : AbpPageModel
{
    protected LocationServicePageModel()
    {
        LocalizationResourceType = typeof(LocationServiceResource);
        ObjectMapperContext = typeof(LocationServiceWebModule);
    }
}
