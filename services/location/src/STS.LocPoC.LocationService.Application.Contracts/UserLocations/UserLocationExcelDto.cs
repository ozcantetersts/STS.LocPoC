using System;

namespace STS.LocPoC.LocationService.UserLocations
{
    public class UserLocationExcelDto
    {
        public int UserId { get; set; }
        public string Longitude { get; set; } = null!;
        public string Latitude { get; set; } = null!;
    }
}