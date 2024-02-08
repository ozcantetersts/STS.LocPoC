using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using STS.LocPoC.LocationService.UserLocations;
using STS.LocPoC.LocationService.EntityFrameworkCore;
using Xunit;

namespace STS.LocPoC.LocationService.EntityFrameworkCore.Domains.UserLocations
{
    public class UserLocationRepositoryTests : LocationServiceEntityFrameworkCoreTestBase
    {
        private readonly IUserLocationRepository _userLocationRepository;

        public UserLocationRepositoryTests()
        {
            _userLocationRepository = GetRequiredService<IUserLocationRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _userLocationRepository.GetListAsync(
                    longitude: "d2b130f60bcf4112ae12ed9ec01404e4bab78ddfadb34fc49947b6b0a773094615",
                    latitude: "146a9ed7d5d34edba330948"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("356bd700-a2a5-4534-be42-6b284e7a5097"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _userLocationRepository.GetCountAsync(
                    longitude: "7993f544c09d46f4b32c66c212c2da6a41d759ba2a434165b77300e2eb18e1a147ec9ccad24a409eb2c24b",
                    latitude: "6bf1f6a"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}