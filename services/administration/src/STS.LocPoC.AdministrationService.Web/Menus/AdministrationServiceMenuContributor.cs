using System.Threading.Tasks;
using STS.LocPoC.AdministrationService.Localization;
using Volo.Abp.UI.Navigation;

namespace STS.LocPoC.AdministrationService.Web.Menus;

public class AdministrationServiceMenuContributor : IMenuContributor
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
        var l = context.GetLocalizer<AdministrationServiceResource>();
        return Task.CompletedTask;
    }
}
