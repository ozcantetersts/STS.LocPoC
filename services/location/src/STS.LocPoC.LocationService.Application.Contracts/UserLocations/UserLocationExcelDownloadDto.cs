using Volo.Abp.Application.Dtos;
using System;

namespace STS.LocPoC.LocationService.UserLocations
{
    public class UserLocationExcelDownloadDto
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public int? UserIdMin { get; set; }
        public int? UserIdMax { get; set; }
        public string? Longitude { get; set; }
        public string? Latitude { get; set; }

        public UserLocationExcelDownloadDto()
        {

        }
    }
}