using STS.LocPoC.LocationService.Permissions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
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

        var moduleMenu = AddModuleMenuItem(context);
        AddMenuItemUserLocations(context, moduleMenu);
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<LocationServiceResource>();
        return Task.CompletedTask;
    }
    private static ApplicationMenuItem AddModuleMenuItem(MenuConfigurationContext context)
    {
        var moduleMenu = new ApplicationMenuItem(
            LocationServiceMenus.Prefix,
            context.GetLocalizer<LocationServiceResource>()["Menu:LocationService"],
            icon: "fa fa-folder"
        );

        context.Menu.Items.AddIfNotContains(moduleMenu);
        return moduleMenu;
    }
    private static void AddMenuItemUserLocations(MenuConfigurationContext context, ApplicationMenuItem parentMenu)
    {
        parentMenu.AddItem(
            new ApplicationMenuItem(
                Menus.LocationServiceMenus.UserLocations,
                context.GetLocalizer<LocationServiceResource>()["Menu:UserLocations"],
                "/UserLocations",
                icon: "fa fa-file-alt",
                requiredPermissionName: LocationServicePermissions.UserLocations.Default
            )
        );
    }
}