using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using STS.LocPoC.LocationService.EntityFrameworkCore;

namespace STS.LocPoC.LocationService.UserLocations
{
    public class EfCoreUserLocationRepository : EfCoreRepository<LocationServiceDbContext, UserLocation, Guid>, IUserLocationRepository
    {
        public EfCoreUserLocationRepository(IDbContextProvider<LocationServiceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<List<UserLocation>> GetListAsync(
            string? filterText = null,
            int? userIdMin = null,
            int? userIdMax = null,
            string? longitude = null,
            string? latitude = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, userIdMin, userIdMax, longitude, latitude);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? UserLocationConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            int? userIdMin = null,
            int? userIdMax = null,
            string? longitude = null,
            string? latitude = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, userIdMin, userIdMax, longitude, latitude);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<UserLocation> ApplyFilter(
            IQueryable<UserLocation> query,
            string? filterText = null,
            int? userIdMin = null,
            int? userIdMax = null,
            string? longitude = null,
            string? latitude = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Longitude!.Contains(filterText!) || e.Latitude!.Contains(filterText!))
                    .WhereIf(userIdMin.HasValue, e => e.UserId >= userIdMin!.Value)
                    .WhereIf(userIdMax.HasValue, e => e.UserId <= userIdMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(longitude), e => e.Longitude.Contains(longitude))
                    .WhereIf(!string.IsNullOrWhiteSpace(latitude), e => e.Latitude.Contains(latitude));
        }
    }
}