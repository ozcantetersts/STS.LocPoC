using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace STS.LocPoC.LocationService.UserLocations
{
    public class UserLocationUpdateDto : IHasConcurrencyStamp
    {
        public int UserId { get; set; }
        [Required]
        public string Longitude { get; set; } = null!;
        [Required]
        public string Latitude { get; set; } = null!;

        public string ConcurrencyStamp { get; set; } = null!;
    }
}