using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using STS.LocPoC.LocationService.Shared;

namespace STS.LocPoC.LocationService.UserLocations
{
    public interface IUserLocationsAppService : IApplicationService
    {

        Task<PagedResultDto<UserLocationDto>> GetListAsync(GetUserLocationsInput input);

        Task<UserLocationDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<UserLocationDto> CreateAsync(UserLocationCreateDto input);

        Task<UserLocationDto> UpdateAsync(Guid id, UserLocationUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserLocationExcelDownloadDto input);

        Task<STS.LocPoC.LocationService.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}