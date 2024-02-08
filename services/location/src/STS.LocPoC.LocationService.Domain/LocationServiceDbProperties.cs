namespace STS.LocPoC.LocationService;

public static class LocationServiceDbProperties
{
    public static string DbTablePrefix { get; set; } = "";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "LocationService";
}
