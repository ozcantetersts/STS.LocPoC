using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using STS.LocPoC.LocationService.UserLocations;
using Volo.Abp.Content;
using STS.LocPoC.LocationService.Shared;

namespace STS.LocPoC.LocationService.UserLocations
{
    [RemoteService(Name = LocationServiceRemoteServiceConsts.RemoteServiceName)]
    [Area("locationService")]
    [Route("api/location-service/user-locations")]
    public class UserLocationController : LocationServiceController, IUserLocationsAppService
    {
        protected IUserLocationsAppService _userLocationsAppService;

        public UserLocationController(IUserLocationsAppService userLocationsAppService)
        {
            _userLocationsAppService = userLocationsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<UserLocationDto>> GetListAsync(GetUserLocationsInput input)
        {
            return _userLocationsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<UserLocationDto> GetAsync(Guid id)
        {
            return _userLocationsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<UserLocationDto> CreateAsync(UserLocationCreateDto input)
        {
            return _userLocationsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<UserLocationDto> UpdateAsync(Guid id, UserLocationUpdateDto input)
        {
            return _userLocationsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _userLocationsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserLocationExcelDownloadDto input)
        {
            return _userLocationsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<STS.LocPoC.LocationService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _userLocationsAppService.GetDownloadTokenAsync();
        }
    }
}