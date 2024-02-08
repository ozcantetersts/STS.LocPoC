using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using STS.LocPoC.LocationService.Permissions;
using STS.LocPoC.LocationService.UserLocations;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using STS.LocPoC.LocationService.Shared;

namespace STS.LocPoC.LocationService.UserLocations
{

    [Authorize(LocationServicePermissions.UserLocations.Default)]
    public class UserLocationsAppService : LocationServiceAppService, IUserLocationsAppService
    {
        protected IDistributedCache<UserLocationExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        protected IUserLocationRepository _userLocationRepository;
        protected UserLocationManager _userLocationManager;

        public UserLocationsAppService(IUserLocationRepository userLocationRepository, UserLocationManager userLocationManager, IDistributedCache<UserLocationExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _userLocationRepository = userLocationRepository;
            _userLocationManager = userLocationManager;
        }

        public virtual async Task<PagedResultDto<UserLocationDto>> GetListAsync(GetUserLocationsInput input)
        {
            var totalCount = await _userLocationRepository.GetCountAsync(input.FilterText, input.UserIdMin, input.UserIdMax, input.Longitude, input.Latitude);
            var items = await _userLocationRepository.GetListAsync(input.FilterText, input.UserIdMin, input.UserIdMax, input.Longitude, input.Latitude, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<UserLocationDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<UserLocation>, List<UserLocationDto>>(items)
            };
        }

        public virtual async Task<UserLocationDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<UserLocation, UserLocationDto>(await _userLocationRepository.GetAsync(id));
        }

        [Authorize(LocationServicePermissions.UserLocations.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _userLocationRepository.DeleteAsync(id);
        }

        [Authorize(LocationServicePermissions.UserLocations.Create)]
        public virtual async Task<UserLocationDto> CreateAsync(UserLocationCreateDto input)
        {

            var userLocation = await _userLocationManager.CreateAsync(
            input.UserId, input.Longitude, input.Latitude
            );

            return ObjectMapper.Map<UserLocation, UserLocationDto>(userLocation);
        }

        [Authorize(LocationServicePermissions.UserLocations.Edit)]
        public virtual async Task<UserLocationDto> UpdateAsync(Guid id, UserLocationUpdateDto input)
        {

            var userLocation = await _userLocationManager.UpdateAsync(
            id,
            input.UserId, input.Longitude, input.Latitude, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<UserLocation, UserLocationDto>(userLocation);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserLocationExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _userLocationRepository.GetListAsync(input.FilterText, input.UserIdMin, input.UserIdMax, input.Longitude, input.Latitude);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<UserLocation>, List<UserLocationExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "UserLocations.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public virtual async Task<STS.LocPoC.LocationService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new UserLocationExcelDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new STS.LocPoC.LocationService.Shared.DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}