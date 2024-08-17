using DataLayer;
using DataLayer.Data.Repositories.Interfaces;
using NSubstitute;
using task_1.Entities;
using Xunit;

namespace UnitTests.DataLayerTests
{
    public class DataSeederTests
    {
        [Fact]
        public async Task TestSeed()
        {
            // Arrange
            var storageRepository = Substitute.For<IStorageRepository>();

            var unitOfWork = Substitute.For<IUnitOfWork>();

            unitOfWork.StorageRepository.Returns(storageRepository);

            var dataSeeder = new DataSeeder(unitOfWork);

            // Act
            await dataSeeder.Seed();

            // Assert
            await storageRepository.Received(1).Create(Arg.Is<Storage>(strg =>
                strg.No == 1 &&
                strg.Addres == "Default" &&
                strg.Id == Guid.NewGuid() &&
                strg.ManagerID == Guid.NewGuid()
                ));

            await unitOfWork.Received(1).SaveChangesAsync();
        }
    }
}