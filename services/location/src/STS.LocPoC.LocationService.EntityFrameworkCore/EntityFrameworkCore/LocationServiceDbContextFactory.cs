using System.IO;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Volo.Abp;

namespace STS.LocPoC.LocationService.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands)
 *
 * It is also used in the DbMigrator application.
 * */
public class LocationServiceDbContextFactory : IDesignTimeDbContextFactory<LocationServiceDbContext>
{
    private readonly string _connectionString;

    /* This constructor is used when you use EF Core tooling (e.g. Update-Database) */
    public LocationServiceDbContextFactory()
    {
        _connectionString = GetConnectionStringFromConfiguration();
    }

    /* This constructor is used by DbMigrator application */
    public LocationServiceDbContextFactory([NotNull] string connectionString)
    {
        Check.NotNullOrWhiteSpace(connectionString, nameof(connectionString));
        _connectionString = connectionString;
    }

    public LocationServiceDbContext CreateDbContext(string[] args)
    {
        LocationServiceEfCoreEntityExtensionMappings.Configure();
        
        var builder = new DbContextOptionsBuilder<LocationServiceDbContext>()
            .UseSqlServer(_connectionString, b =>
            {
                b.MigrationsHistoryTable("__LocationService_Migrations");
            });

        return new LocationServiceDbContext(builder.Options);
    }

    private static string GetConnectionStringFromConfiguration()
    {
        return BuildConfiguration()
            .GetConnectionString(LocationServiceDbProperties.ConnectionStringName);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    $"..{Path.DirectorySeparatorChar}STS.LocPoC.LocationService.HttpApi.Host"
                )
            )
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
