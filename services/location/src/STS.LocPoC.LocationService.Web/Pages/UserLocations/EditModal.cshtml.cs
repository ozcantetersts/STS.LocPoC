using STS.LocPoC.LocationService.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using STS.LocPoC.LocationService.UserLocations;

namespace STS.LocPoC.LocationService.Web.Pages.UserLocations
{
    public class EditModalModel : LocationServicePageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public UserLocationUpdateViewModel UserLocation { get; set; }

        protected IUserLocationsAppService _userLocationsAppService;

        public EditModalModel(IUserLocationsAppService userLocationsAppService)
        {
            _userLocationsAppService = userLocationsAppService;

            UserLocation = new();
        }

        public virtual async Task OnGetAsync()
        {
            var userLocation = await _userLocationsAppService.GetAsync(Id);
            UserLocation = ObjectMapper.Map<UserLocationDto, UserLocationUpdateViewModel>(userLocation);

        }

        public virtual async Task<NoContentResult> OnPostAsync()
        {

            await _userLocationsAppService.UpdateAsync(Id, ObjectMapper.Map<UserLocationUpdateViewModel, UserLocationUpdateDto>(UserLocation));
            return NoContent();
        }
    }

    public class UserLocationUpdateViewModel : UserLocationUpdateDto
    {
    }
}