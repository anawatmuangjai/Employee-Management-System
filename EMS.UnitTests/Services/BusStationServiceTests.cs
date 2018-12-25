using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.ApplicationCore.Services;
using EMS.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.UnitTests.Services
{
    [TestClass]
    public class BusStationServiceTests
    {
        private MasterBusStation _busStation;
        private List<MasterBusStation> _busStations;
        private Mock<IAsyncRepository<MasterBusStation>> _mockAsyncRepository;
        private IBusStationService _busStationService;

        [TestInitialize]
        public void TestInitialize()
        {
            _busStation = new MasterBusStation
            {
                BusStationId = 1,
                RouteId = 1,
                BusStationName = "A",
                BusStationCode = "B"
            };

            _busStations = new List<MasterBusStation>
            {
                _busStation
            };

            _mockAsyncRepository = new Mock<IAsyncRepository<MasterBusStation>>();

            _mockAsyncRepository
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(_busStations);

            _mockAsyncRepository
                .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(_busStation);

            _busStationService = new BusStationService(_mockAsyncRepository.Object);

        }

        [TestMethod]
        public async Task GetAllAsync_WhenCalled_PopulateExpectedResult()
        {
            // Arrange
            //var expectedCount = 1;

            // Act
            var actual = await _busStationService.GetAllAsync();

            // Assert

            _mockAsyncRepository.Verify(m => m.GetAllAsync(), Times.Once);

            //_mockAsyncRepository.Verify();
            //Assert.IsTrue(actual.Count == expectedCount);
        }

        [TestMethod]
        public async Task GetByIdAsync_WithSpecifiedId_ReturnExpectedResult()
        {
            // Arrange
            var busStationId = 1;
            var expectedName = "A";

            // Act
            var actual = await _busStationService.GetByIdAsync(busStationId);

            // Assert
            _mockAsyncRepository.Verify(m => m.GetByIdAsync(1), Times.Once);
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedName, actual.BusStationName);
        }

        [TestMethod]
        public async Task AddAsync_WhenCalled_InvokesRepositoryAddMethod()
        {
            // Arrange
            var busStation = new BusStationModel();

            // Act
            await _busStationService.AddAsync(busStation);

            // Assert
            _mockAsyncRepository.Verify(m => m.AddAsync(It.IsAny<MasterBusStation>()), Times.Once);
        }

        [TestMethod]
        public async Task UpdateAsync_WhenCalled_InvokesRepositoryUpdateMethod()
        {
            // Arrange
            var busStation = new BusStationModel();

            // Act
            await _busStationService.UpdateAsync(busStation);

            // Assert
            _mockAsyncRepository.Verify(m => m.UpdateAsync(It.IsAny<MasterBusStation>()), Times.Once);
        }

        [TestMethod]
        public async Task DeleteAsync_WhenCalled_InvokesRepositoryDeleteMethod()
        {
            // Arrange
            var busStation = new BusStationModel();

            // Act
            await _busStationService.DeleteAsync(1);

            // Assert
            _mockAsyncRepository.Verify(m => m.DeleteAsync(It.IsAny<MasterBusStation>()), Times.Once);
        }
    }
}
