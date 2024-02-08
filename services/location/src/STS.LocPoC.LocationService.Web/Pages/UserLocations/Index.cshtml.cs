using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using STS.LocPoC.LocationService.UserLocations;
using STS.LocPoC.LocationService.Shared;

namespace STS.LocPoC.LocationService.Web.Pages.UserLocations
{
    public class IndexModel : AbpPageModel
    {
        public int? UserIdFilterMin { get; set; }

        public int? UserIdFilterMax { get; set; }
        public string? LongitudeFilter { get; set; }
        public string? LatitudeFilter { get; set; }

        protected IUserLocationsAppService _userLocationsAppService;

        public IndexModel(IUserLocationsAppService userLocationsAppService)
        {
            _userLocationsAppService = userLocationsAppService;
        }

        public virtual async Task OnGetAsync()
        {

            await Task.CompletedTask;
        }
    }
}