using Volo.Abp.Reflection;

namespace STS.LocPoC.LocationService.Permissions;

public class LocationServicePermissions
{
    public const string GroupName = "LocationService";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(LocationServicePermissions));
    }

    public static class UserLocations
    {
        public const string Default = GroupName + ".UserLocations";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}