using STS.LocPoC.LocationService.UserLocations;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace STS.LocPoC.LocationService.EntityFrameworkCore;

[ConnectionStringName(LocationServiceDbProperties.ConnectionStringName)]
public class LocationServiceDbContext : AbpDbContext<LocationServiceDbContext>
{
    public DbSet<UserLocation> UserLocations { get; set; } = null!;

    public LocationServiceDbContext(DbContextOptions<LocationServiceDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureLocationService();
    }
}