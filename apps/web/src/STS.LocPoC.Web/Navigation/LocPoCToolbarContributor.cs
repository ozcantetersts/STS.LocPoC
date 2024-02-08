using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using STS.LocPoC.Web.Components.Toolbar.LoginLink;
using STS.LocPoC.Web.Components.Toolbar.Impersonation;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Toolbars;
using Volo.Abp.Users;

namespace STS.LocPoC.Web.Navigation;

public class LocPoCToolbarContributor : IToolbarContributor
{
    public virtual Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
    {
        if (context.Toolbar.Name != StandardToolbars.Main)
        {
            return Task.CompletedTask;
        }

        var currentUser = context.ServiceProvider.GetRequiredService<ICurrentUser>();

        if (!currentUser.IsAuthenticated)
        {
            context.Toolbar.Items.Add(new ToolbarItem(typeof(LoginLinkViewComponent)));
        }

        if (currentUser.FindImpersonatorUserId() != null)
        {
            context.Toolbar.Items.Add(new ToolbarItem(typeof(ImpersonationViewComponent), order: -1));
        }

        return Task.CompletedTask;
    }
}
