using Microsoft.Extensions.DependencyInjection;
using STS.LocPoC.Shared.Hosting.AspNetCore;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;

namespace STS.LocPoC.Shared.Hosting.Gateways;

[DependsOn(
    typeof(LocPoCSharedHostingAspNetCoreModule),    
    typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
    typeof(AbpSwashbuckleModule)
)]
public class LocPoCSharedHostingGatewaysModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var env = context.Services.GetHostingEnvironment();

        context.Services.AddReverseProxy()
            .LoadFromConfig(configuration.GetSection("ReverseProxy"));
    }
}
