using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.Domain.Entities;
using EMS.Persistance.Context;
using EMS.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.IntegrationTests.Repositories
{
    [TestClass]
    public class JobRepositoryTests
    {
        private MasterJobPosition _jobPosition;
        private EmployeeContext _context;
        private IAsyncRepository<MasterJobPosition> _repository;

        [TestInitialize]
        public void TestInitialize()
        {
            _jobPosition = new MasterJobPosition
            {
                PositionName = "A",
                PositionCode = "A"
            };

            var option = new DbContextOptionsBuilder<EmployeeContext>()
                .UseInMemoryDatabase(databaseName: "TestEmployee")
                .Options;

            _context = new EmployeeContext(option);
            _repository = new Repository<MasterJobPosition>(_context);
        }

        [TestMethod]
        public async Task GetByIdAysnc_WithSpecifiedId_ReturnExpectedResult()
        {
            // Arrange
            await _repository.AddAsync(_jobPosition);
            var jobPositionId = 1;
            var jobPositionExpected = "A";

            // Act
            var actaul = await _repository.GetByIdAsync(jobPositionId);

            // Assert
            Assert.AreEqual(jobPositionExpected, actaul.PositionName);
        }

        [TestMethod]
        public async Task GetAllAsync_WhenCall_PopulateResult()
        {
            // Arrange
            await _repository.AddAsync(_jobPosition);

            // Act
            var items = await _repository.GetAllAsync();

            // Assert
            Assert.IsTrue(items.Count > 0, "No items");
        }

        [TestMethod]
        public async Task AddAsync_NewItem_ReturnAssignedId()
        {
            // Arrange
            await _repository.AddAsync(_jobPosition);

            // Act
            var items = await _repository.GetAllAsync();
            var newItem = items.FirstOrDefault();

            // Assert
            Assert.IsTrue(items.Count > 0, "No items");
            Assert.IsTrue(newItem.PositionId > 0, "Add new item does not return id");
        }

        [TestMethod]
        public async Task UpdateAsync_ExistingItem_NotSameResult()
        {
            // Arrange
            await _repository.AddAsync(_jobPosition);
            var newItem = await _repository.GetByIdAsync(1);
            newItem.PositionName = "B";
            newItem.PositionCode = "B";

            // Act
            await _repository.UpdateAsync(newItem);
            var updatedItem = await _repository.GetByIdAsync(1);

            // Assert
            Assert.IsNotNull(updatedItem);
            Assert.AreEqual("B", updatedItem.PositionName, "Record is not updated");
        }

        [TestMethod]
        public async Task DeleteAsync_WithSepecifiedId_RemoveExistingItem()
        {
            // Arrange
            await _repository.AddAsync(_jobPosition);
            var existingItem = await _repository.GetByIdAsync(1);

            // Act
            await _repository.DeleteAsync(existingItem);
            existingItem = await _repository.GetByIdAsync(1);

            // Assert
            Assert.IsNull(existingItem, "Record is not deleted");
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            _context.Dispose();
        }
    }
}
