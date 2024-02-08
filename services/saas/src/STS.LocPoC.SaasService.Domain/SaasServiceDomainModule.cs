using Volo.Abp.Modularity;
using Volo.Saas;
using Volo.Payment;

namespace STS.LocPoC.SaasService;

[DependsOn(
    typeof(SaasServiceDomainSharedModule),
    typeof(SaasDomainModule),
    typeof(AbpPaymentDomainModule)
)]
public class SaasServiceDomainModule : AbpModule
{
}
