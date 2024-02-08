using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace STS.LocPoC.LocationService.UserLocations
{
    public class UserLocationDto : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public int UserId { get; set; }
        public string Longitude { get; set; } = null!;
        public string Latitude { get; set; } = null!;

        public string ConcurrencyStamp { get; set; } = null!;

    }
}