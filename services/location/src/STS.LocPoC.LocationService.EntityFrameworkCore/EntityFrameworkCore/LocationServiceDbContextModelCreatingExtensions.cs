using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace STS.LocPoC.LocationService.EntityFrameworkCore;

public static class LocationServiceDbContextModelCreatingExtensions
{
    public static void ConfigureLocationService(this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(LocationServiceConsts.DbTablePrefix + "YourEntities", LocationServiceConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
