using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace STS.LocPoC.LocationService.UserLocations
{
    public class UserLocation : FullAuditedAggregateRoot<Guid>
    {
        public virtual int UserId { get; set; }

        [NotNull]
        public virtual string Longitude { get; set; }

        [NotNull]
        public virtual string Latitude { get; set; }

        protected UserLocation()
        {

        }

        public UserLocation(Guid id, int userId, string longitude, string latitude)
        {

            Id = id;
            Check.NotNull(longitude, nameof(longitude));
            Check.NotNull(latitude, nameof(latitude));
            UserId = userId;
            Longitude = longitude;
            Latitude = latitude;
        }

    }
}