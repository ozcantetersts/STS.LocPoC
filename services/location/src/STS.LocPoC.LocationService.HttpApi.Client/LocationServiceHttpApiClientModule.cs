using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace STS.LocPoC.LocationService;

[DependsOn(
    typeof(LocationServiceApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class LocationServiceHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddStaticHttpClientProxies(typeof(LocationServiceApplicationContractsModule).Assembly,
            LocationServiceRemoteServiceConsts.RemoteServiceName);

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<LocationServiceHttpApiClientModule>();
        });
    }
}
