using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace STS.LocPoC.LocationService.EntityFrameworkCore;

[ConnectionStringName(LocationServiceDbProperties.ConnectionStringName)]
public class LocationServiceDbContext : AbpDbContext<LocationServiceDbContext>
{

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
