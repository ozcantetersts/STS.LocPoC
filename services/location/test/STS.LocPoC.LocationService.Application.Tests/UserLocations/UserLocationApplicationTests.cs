using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace STS.LocPoC.LocationService.UserLocations
{
    public abstract class UserLocationsAppServiceTests<TStartupModule> : LocationServiceApplicationTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        private readonly IUserLocationsAppService _userLocationsAppService;
        private readonly IRepository<UserLocation, Guid> _userLocationRepository;

        public UserLocationsAppServiceTests()
        {
            _userLocationsAppService = GetRequiredService<IUserLocationsAppService>();
            _userLocationRepository = GetRequiredService<IRepository<UserLocation, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _userLocationsAppService.GetListAsync(new GetUserLocationsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("356bd700-a2a5-4534-be42-6b284e7a5097")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("e16baaca-75d4-4fea-8933-02390f3447ac")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _userLocationsAppService.GetAsync(Guid.Parse("356bd700-a2a5-4534-be42-6b284e7a5097"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("356bd700-a2a5-4534-be42-6b284e7a5097"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new UserLocationCreateDto
            {
                UserId = 15996208,
                Longitude = "8fdc3df61939437bb6ef96df84a2b52b1168fadb731646e890ac872ca50447456ba3bd53e2a04718a6c01a",
                Latitude = "48a0d85b4deb45dfb4b9ebe6de6142971f0aae1fb91240da92ce981fb3e8f2cd40c1cfb23a51"
            };

            // Act
            var serviceResult = await _userLocationsAppService.CreateAsync(input);

            // Assert
            var result = await _userLocationRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserId.ShouldBe(15996208);
            result.Longitude.ShouldBe("8fdc3df61939437bb6ef96df84a2b52b1168fadb731646e890ac872ca50447456ba3bd53e2a04718a6c01a");
            result.Latitude.ShouldBe("48a0d85b4deb45dfb4b9ebe6de6142971f0aae1fb91240da92ce981fb3e8f2cd40c1cfb23a51");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new UserLocationUpdateDto()
            {
                UserId = 1077712619,
                Longitude = "7e522b1293fe4ad2a6f50cea43385e81207eab2a8c134b3b867c966d723485f6dc1dcdf9e",
                Latitude = "3ffe8589dbb9439cab92afc235b02f257cb2fe"
            };

            // Act
            var serviceResult = await _userLocationsAppService.UpdateAsync(Guid.Parse("356bd700-a2a5-4534-be42-6b284e7a5097"), input);

            // Assert
            var result = await _userLocationRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserId.ShouldBe(1077712619);
            result.Longitude.ShouldBe("7e522b1293fe4ad2a6f50cea43385e81207eab2a8c134b3b867c966d723485f6dc1dcdf9e");
            result.Latitude.ShouldBe("3ffe8589dbb9439cab92afc235b02f257cb2fe");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _userLocationsAppService.DeleteAsync(Guid.Parse("356bd700-a2a5-4534-be42-6b284e7a5097"));

            // Assert
            var result = await _userLocationRepository.FindAsync(c => c.Id == Guid.Parse("356bd700-a2a5-4534-be42-6b284e7a5097"));

            result.ShouldBeNull();
        }
    }
}