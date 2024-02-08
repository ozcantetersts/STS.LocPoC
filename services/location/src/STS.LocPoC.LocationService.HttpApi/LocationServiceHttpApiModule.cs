using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using STS.LocPoC.LocationService.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace STS.LocPoC.LocationService;

[DependsOn(
    typeof(LocationServiceApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class LocationServiceHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(LocationServiceHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<LocationServiceResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
