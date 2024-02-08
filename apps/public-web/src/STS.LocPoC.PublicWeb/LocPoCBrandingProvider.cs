using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace STS.LocPoC.PublicWeb;

[Dependency(ReplaceServices = true)]
public class LocPoCBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "LocPoC";
}
