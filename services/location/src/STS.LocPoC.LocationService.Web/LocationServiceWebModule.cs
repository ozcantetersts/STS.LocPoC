using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using STS.LocPoC.LocationService.Localization;
using STS.LocPoC.LocationService.Permissions;
using STS.LocPoC.LocationService.Web.Menus;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;

namespace STS.LocPoC.LocationService.Web;

[DependsOn(
    typeof(LocationServiceApplicationContractsModule),
    typeof(AbpAspNetCoreMvcUiThemeSharedModule),
    typeof(AbpAutoMapperModule)
    )]
public class LocationServiceWebModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
        {
            options.AddAssemblyResource(typeof(LocationServiceResource), typeof(LocationServiceWebModule).Assembly);
        });

        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(LocationServiceWebModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new LocationServiceMenuContributor());
        });

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<LocationServiceWebModule>();
        });

        context.Services.AddAutoMapperObjectMapper<LocationServiceWebModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<LocationServiceWebModule>(validate: true);
        });

        Configure<RazorPagesOptions>(options =>
        {
            // options.Conventions.AuthorizePage("/LocationService/Index", LocationServicePermissions.LocationService.Default);
            options.Conventions.AuthorizePage("/UserLocations/Index", LocationServicePermissions.UserLocations.Default);
        });
    }
}