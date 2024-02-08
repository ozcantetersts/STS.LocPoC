using STS.LocPoC.LocationService.Web.Pages.UserLocations;
using Volo.Abp.AutoMapper;
using STS.LocPoC.LocationService.UserLocations;
using AutoMapper;

namespace STS.LocPoC.LocationService.Web;

public class LocationServiceWebAutoMapperProfile : Profile
{
    public LocationServiceWebAutoMapperProfile()
    {

        CreateMap<UserLocationDto, UserLocationUpdateViewModel>();
        CreateMap<UserLocationUpdateViewModel, UserLocationUpdateDto>();
        CreateMap<UserLocationCreateViewModel, UserLocationCreateDto>();
    }
}