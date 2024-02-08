using Volo.Abp.EntityFrameworkCore.Modeling;
using STS.LocPoC.LocationService.UserLocations;
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
        if (builder.IsHostDatabase())
        {
            builder.Entity<UserLocation>(b =>
            {
                b.ToTable(LocationServiceDbProperties.DbTablePrefix + "UserLocations", LocationServiceDbProperties.DbSchema);
                b.ConfigureByConvention();
                b.Property(x => x.UserId).HasColumnName(nameof(UserLocation.UserId));
                b.Property(x => x.Longitude).HasColumnName(nameof(UserLocation.Longitude)).IsRequired();
                b.Property(x => x.Latitude).HasColumnName(nameof(UserLocation.Latitude)).IsRequired();
            });

        }
    }
}