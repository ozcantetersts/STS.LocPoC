using STS.LocPoC.LocationService.Shared;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using STS.LocPoC.LocationService.UserLocations;

namespace STS.LocPoC.LocationService.Web.Pages.UserLocations
{
    public class CreateModalModel : LocationServicePageModel
    {

        [BindProperty]
        public UserLocationCreateViewModel UserLocation { get; set; }

        protected IUserLocationsAppService _userLocationsAppService;

        public CreateModalModel(IUserLocationsAppService userLocationsAppService)
        {
            _userLocationsAppService = userLocationsAppService;

            UserLocation = new();
        }

        public virtual async Task OnGetAsync()
        {
            UserLocation = new UserLocationCreateViewModel();

            await Task.CompletedTask;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {

            await _userLocationsAppService.CreateAsync(ObjectMapper.Map<UserLocationCreateViewModel, UserLocationCreateDto>(UserLocation));
            return NoContent();
        }
    }

    public class UserLocationCreateViewModel : UserLocationCreateDto
    {
    }
}