using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace STS.LocPoC.LocationService.UserLocations
{
    public interface IUserLocationRepository : IRepository<UserLocation, Guid>
    {
        Task<List<UserLocation>> GetListAsync(
            string? filterText = null,
            int? userIdMin = null,
            int? userIdMax = null,
            string? longitude = null,
            string? latitude = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string? filterText = null,
            int? userIdMin = null,
            int? userIdMax = null,
            string? longitude = null,
            string? latitude = null,
            CancellationToken cancellationToken = default);
    }
}