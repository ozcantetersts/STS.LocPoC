using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using STS.LocPoC.LocationService.DbMigrations;
using STS.LocPoC.LocationService.EntityFrameworkCore;
using STS.LocPoC.Shared.Hosting.Microservices;
using STS.LocPoC.Shared.Hosting.AspNetCore;
using Prometheus;
using Volo.Abp;
using Volo.Abp.Modularity;
using Volo.Abp.Security.Claims;

namespace STS.LocPoC.LocationService;

[DependsOn(
    typeof(LocPoCSharedHostingMicroservicesModule),
    typeof(LocationServiceApplicationModule),
    typeof(LocationServiceHttpApiModule),
    typeof(LocationServiceEntityFrameworkCoreModule)
    )]
public class LocationServiceHttpApiHostModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //You can disable this setting in production to avoid any potential security risks.
        Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;

        // Enable if you need these
        // var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        JwtBearerConfigurationHelper.Configure(context, "LocationService");
        SwaggerConfigurationHelper.ConfigureWithOidc(
            context: context,
            authority: configuration["AuthServer:Authority"]!,
            scopes: new[] { "LocationService" },
            flows: new[] { "authorization_code" },
            discoveryEndpoint: configuration["AuthServer:MetadataAddress"],
            apiTitle: "LocationService Service API"
        );
        context.Services.Configure<AbpClaimsPrincipalFactoryOptions>(options =>
        {
            options.IsDynamicClaimsEnabled = true;
        });
        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(
                        configuration["App:CorsOrigins"]?
                            .Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(o => o.Trim().RemovePostFix("/"))
                            .ToArray()
                    )
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCorrelationId();
        app.UseAbpRequestLocalization();
        app.UseAbpSecurityHeaders();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();
        app.UseAbpClaimsMap();
        app.UseMultiTenancy();
        app.UseUnitOfWork();
        app.UseDynamicClaims();
        app.UseAuthorization();
        app.UseSwagger();
        app.UseAbpSwaggerUI(options =>
        {
            var configuration = context.ServiceProvider.GetRequiredService<IConfiguration>();
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "LocationService API");
            options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
        });
        app.UseAbpSerilogEnrichers();
        app.UseAuditing();
        app.UseConfiguredEndpoints(endpoints => endpoints.MapMetrics());
    }

    public async override Task OnPostApplicationInitializationAsync(ApplicationInitializationContext context)
    {
        using (var scope = context.ServiceProvider.CreateScope())
        {
            await scope.ServiceProvider
                .GetRequiredService<LocationServiceDatabaseMigrationChecker>()
                .CheckAndApplyDatabaseMigrationsAsync();
        }
    }
}
