using System.Threading.Tasks;
using STS.LocPoC.LocationService.Localization;
using Volo.Abp.UI.Navigation;

namespace STS.LocPoC.LocationService.Web.Menus;

public class LocationServiceMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<LocationServiceResource>();
        return Task.CompletedTask;
    }
}
