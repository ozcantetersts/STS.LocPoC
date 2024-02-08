using System;
using STS.LocPoC.LocationService.Shared;
using Volo.Abp.AutoMapper;
using STS.LocPoC.LocationService.UserLocations;
using AutoMapper;

namespace STS.LocPoC.LocationService;

public class LocationServiceApplicationAutoMapperProfile : Profile
{
    public LocationServiceApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
        * Alternatively, you can split your mapping configurations
        * into multiple profile classes for a better organization. */

        CreateMap<UserLocation, UserLocationDto>();
        CreateMap<UserLocation, UserLocationExcelDto>();
    }
}