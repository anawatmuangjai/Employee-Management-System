using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.Domain.Entities;
using EMS.Persistance.Context;
using EMS.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.IntegrationTests.Repositories
{
    [TestClass]
    public class DepartmentRepositoryTests : TestBase
    {
        private EmployeeContext _context;
        private IAsyncRepository<MasterDepartment> _departmentRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            var option = new DbContextOptionsBuilder<EmployeeContext>()
            .UseSqlServer(Configuration.GetConnectionString("EmployeeConnection"))
            .Options;

            _context = new EmployeeContext(option);
            _departmentRepository = new Repository<MasterDepartment>(_context);
        }

        [TestMethod]
        public async Task GetById_WithSpecificId_ReturnExpectedDepartmentCode()
        {
            var departmentId = 1;
            var departmentCode = "AMT-AM";

            var actual = await _departmentRepository.GetByIdAsync(departmentId);

            Assert.IsNotNull(actual);
            Assert.AreEqual(departmentCode, actual.DepartmentCode);
        }
    }
}
