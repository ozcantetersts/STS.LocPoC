using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace STS.LocPoC.LocationService.UserLocations
{
    public class UserLocationCreateDto
    {
        public int UserId { get; set; }
        [Required]
        public string Longitude { get; set; } = null!;
        [Required]
        public string Latitude { get; set; } = null!;
    }
}