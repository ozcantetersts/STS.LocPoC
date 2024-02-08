using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using STS.LocPoC.LocationService.UserLocations;

namespace STS.LocPoC.LocationService.UserLocations
{
    public class UserLocationsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IUserLocationRepository _userLocationRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UserLocationsDataSeedContributor(IUserLocationRepository userLocationRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _userLocationRepository = userLocationRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _userLocationRepository.InsertAsync(new UserLocation
            (
                id: Guid.Parse("356bd700-a2a5-4534-be42-6b284e7a5097"),
                userId: 1661448986,
                longitude: "d2b130f60bcf4112ae12ed9ec01404e4bab78ddfadb34fc49947b6b0a773094615",
                latitude: "146a9ed7d5d34edba330948"
            ));

            await _userLocationRepository.InsertAsync(new UserLocation
            (
                id: Guid.Parse("e16baaca-75d4-4fea-8933-02390f3447ac"),
                userId: 122725826,
                longitude: "7993f544c09d46f4b32c66c212c2da6a41d759ba2a434165b77300e2eb18e1a147ec9ccad24a409eb2c24b",
                latitude: "6bf1f6a"
            ));

            await _unitOfWorkManager!.Current!.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}