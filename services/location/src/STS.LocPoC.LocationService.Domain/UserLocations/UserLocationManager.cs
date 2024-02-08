using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace STS.LocPoC.LocationService.UserLocations
{
    public class UserLocationManager : DomainService
    {
        protected IUserLocationRepository _userLocationRepository;

        public UserLocationManager(IUserLocationRepository userLocationRepository)
        {
            _userLocationRepository = userLocationRepository;
        }

        public virtual async Task<UserLocation> CreateAsync(
        int userId, string longitude, string latitude)
        {
            Check.NotNullOrWhiteSpace(longitude, nameof(longitude));
            Check.NotNullOrWhiteSpace(latitude, nameof(latitude));

            var userLocation = new UserLocation(
             GuidGenerator.Create(),
             userId, longitude, latitude
             );

            return await _userLocationRepository.InsertAsync(userLocation);
        }

        public virtual async Task<UserLocation> UpdateAsync(
            Guid id,
            int userId, string longitude, string latitude, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(longitude, nameof(longitude));
            Check.NotNullOrWhiteSpace(latitude, nameof(latitude));

            var userLocation = await _userLocationRepository.GetAsync(id);

            userLocation.UserId = userId;
            userLocation.Longitude = longitude;
            userLocation.Latitude = latitude;

            userLocation.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _userLocationRepository.UpdateAsync(userLocation);
        }

    }
}