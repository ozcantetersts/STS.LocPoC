namespace STS.LocPoC.LocationService.UserLocations
{
    public static class UserLocationConsts
    {
        private const string DefaultSorting = "{0}UserId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "UserLocation." : string.Empty);
        }

    }
}