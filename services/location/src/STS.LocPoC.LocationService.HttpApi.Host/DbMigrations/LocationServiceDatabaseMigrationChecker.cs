using System;
using Microsoft.Extensions.Logging;
using STS.LocPoC.LocationService.EntityFrameworkCore;
using STS.LocPoC.Shared.Hosting.Microservices.DbMigrations.EfCore;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace STS.LocPoC.LocationService.DbMigrations;

public class LocationServiceDatabaseMigrationChecker : PendingEfCoreMigrationsChecker<LocationServiceDbContext>
{
    public LocationServiceDatabaseMigrationChecker(
        ILoggerFactory loggerFactory,
        IUnitOfWorkManager unitOfWorkManager,
        IServiceProvider serviceProvider,
        ICurrentTenant currentTenant,
        IDistributedEventBus distributedEventBus,
        IAbpDistributedLock abpDistributedLock)
        : base(
            loggerFactory,
            unitOfWorkManager,
            serviceProvider,
            currentTenant,
            distributedEventBus,
            abpDistributedLock,
            LocationServiceDbProperties.ConnectionStringName)
    {

    }
}
