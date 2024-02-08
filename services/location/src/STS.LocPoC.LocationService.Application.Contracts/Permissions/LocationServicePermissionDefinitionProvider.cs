using STS.LocPoC.LocationService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace STS.LocPoC.LocationService.Permissions;

public class LocationServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(LocationServicePermissions.GroupName, L("Permission:LocationService"));

        //Define your own permissions here. Example:
        //myGroup.AddPermission(BookStorePermissions.MyPermission1, L("Permission:MyPermission1"));

        var userLocationPermission = myGroup.AddPermission(LocationServicePermissions.UserLocations.Default, L("Permission:UserLocations"));
        userLocationPermission.AddChild(LocationServicePermissions.UserLocations.Create, L("Permission:Create"));
        userLocationPermission.AddChild(LocationServicePermissions.UserLocations.Edit, L("Permission:Edit"));
        userLocationPermission.AddChild(LocationServicePermissions.UserLocations.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<LocationServiceResource>(name);
    }
}