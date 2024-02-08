using STS.LocPoC.SaasService.Application;
using Volo.Abp.Modularity;

namespace STS.LocPoC.SaasService;

[DependsOn(
    typeof(SaasServiceApplicationModule),
    typeof(SaasServiceDomainTestModule)
    )]
public class SaasServiceApplicationTestModule : AbpModule
{

}
