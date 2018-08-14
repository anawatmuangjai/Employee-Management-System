using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Services;
using EMS.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.UnitTests.Services
{
    [TestClass]
    public class DepartmentServiceTests
    {
        private MasterDepartment _department;
        private List<MasterDepartment> _departments;
        private Mock<IAsyncRepository<MasterDepartment>> _mockAsyncRepository;
        private IDepartmentService _departmentService;

        [TestInitialize]
        public void TestInitialize()
        {
            _department = new MasterDepartment()
            {
                DepartmentId = 1,
                DepartmentName = "A",
                DepartmentCode = "B",
                DepartmentGroup = "C"
            };

            _departments = new List<MasterDepartment>
            {
                _department
            };

            _mockAsyncRepository = new Mock<IAsyncRepository<MasterDepartment>>();
            _mockAsyncRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(_departments);
            _mockAsyncRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(_department);

            _departmentService = new DepartmentService(_mockAsyncRepository.Object);
        }

        [TestMethod]
        public async Task GetAllAysnc_WhenCall_PopulateExpectedResult()
        {
            // Arrange
            var expectedCount = 1;

            // Act
            var actual = await _departmentService.GetAllAsync();

            // Assert
            _mockAsyncRepository.Verify();
            Assert.IsNotNull(actual);
            Assert.AreEqual(expectedCount, actual.Count);
        }

        [TestMethod]
        public async Task GetByIdAsync_WithDepartmentId_ShouldReturnExpectedDepartmentName()
        {
            // Arrange
            var departmentId = 1;
            var expected = "A";

            // Act
            var actual = await _departmentService.GetByIdAsync(departmentId);

            // Assert
            _mockAsyncRepository.Verify();
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual.DepartmentName);
        }
    }
}
