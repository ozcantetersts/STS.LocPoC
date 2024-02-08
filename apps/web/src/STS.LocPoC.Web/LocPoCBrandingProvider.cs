using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace STS.LocPoC.Web;

[Dependency(ReplaceServices = true)]
public class LocPoCBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "LocPoC";
}
