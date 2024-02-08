using Volo.Abp.Reflection;

namespace STS.LocPoC.LocationService.Permissions;

public class LocationServicePermissions
{
    public const string GroupName = "LocationService";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(LocationServicePermissions));
    }
}
