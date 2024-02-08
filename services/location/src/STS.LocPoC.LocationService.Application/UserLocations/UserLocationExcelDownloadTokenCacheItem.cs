using System;

namespace STS.LocPoC.LocationService.UserLocations;

[Serializable]
public class UserLocationExcelDownloadTokenCacheItem
{
    public string Token { get; set; } = null!;
}