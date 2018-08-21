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
        private MasterJobTitle _jobTitle;
        private EmployeeContext _context;
        private IAsyncRepository<MasterJobTitle> _repository;

        [TestInitialize]
        public void TestInitialize()
        {
            _jobTitle = new MasterJobTitle
            {
                JobTitle = "A",
                JobDescription = "A"
            };

            var option = new DbContextOptionsBuilder<EmployeeContext>()
                .UseInMemoryDatabase(databaseName: "TestEmployee")
                .Options;

            _context = new EmployeeContext(option);
            _repository = new Repository<MasterJobTitle>(_context);
        }

        [TestMethod]
        public async Task GetByIdAysnc_WithSpecifiedId_ReturnExpectedResult()
        {
            // Arrange
            await _repository.AddAsync(_jobTitle);
            var jobTitleId = 1;
            var jobTitleExpected = "A";

            // Act
            var actaul = await _repository.GetByIdAsync(jobTitleId);

            // Assert
            Assert.AreEqual(jobTitleExpected, actaul.JobTitle);
        }

        [TestMethod]
        public async Task GetAllAsync_WhenCall_PopulateResult()
        {
            // Arrange
            await _repository.AddAsync(_jobTitle);

            // Act
            var items = await _repository.GetAllAsync();

            // Assert
            Assert.IsTrue(items.Count > 0, "No items");
        }

        [TestMethod]
        public async Task AddAsync_NewItem_ReturnAssignedId()
        {
            // Arrange
            await _repository.AddAsync(_jobTitle);

            // Act
            var items = await _repository.GetAllAsync();
            var newItem = items.FirstOrDefault();

            // Assert
            Assert.IsTrue(items.Count > 0, "No items");
            Assert.IsTrue(newItem.JobTitleId > 0, "Add new item does not return id");
        }

        [TestMethod]
        public async Task UpdateAsync_ExistingItem_NotSameResult()
        {
            // Arrange
            await _repository.AddAsync(_jobTitle);
            var newItem = await _repository.GetByIdAsync(1);
            newItem.JobTitle = "B";
            newItem.JobDescription = "B";

            // Act
            await _repository.UpdateAsync(newItem);
            var updatedItem = await _repository.GetByIdAsync(1);

            // Assert
            Assert.IsNotNull(updatedItem);
            Assert.AreEqual("B", updatedItem.JobTitle, "Record is not updated");
        }

        [TestMethod]
        public async Task DeleteAsync_WithSepecifiedId_RemoveExistingItem()
        {
            // Arrange
            await _repository.AddAsync(_jobTitle);
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
