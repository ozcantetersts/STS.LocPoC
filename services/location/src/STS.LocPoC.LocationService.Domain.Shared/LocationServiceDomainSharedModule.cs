using STS.LocPoC.LocationService.Localization;
using Volo.Abp.Commercial.SuiteTemplates;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace STS.LocPoC.LocationService;

[DependsOn(
    typeof(VoloAbpCommercialSuiteTemplatesModule),
    typeof(AbpValidationModule)
)]
public class LocationServiceDomainSharedModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        LocationServiceModuleExtensionConfigurator.Configure();
        LocationServiceGlobalFeatureConfigurator.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<LocationServiceDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<LocationServiceResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/LocationService");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("LocationService", typeof(LocationServiceResource));
        });
    }
}
