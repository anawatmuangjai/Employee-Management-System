using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.Persistance.Context;
using EMS.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace EMS.IntegrationTests.Repositories
{
    [TestClass]
    public class EmployeeRepositoryTests : TestBase
    {
        private EmployeeContext _context;
        private IEmployeeRepository _employeeRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            var option = new DbContextOptionsBuilder<EmployeeContext>()
            .UseSqlServer(Configuration.GetConnectionString("EmployeeConnection"))
            .Options;

            _context = new EmployeeContext(option);
            _employeeRepository = new EmployeeRepository(_context);
        }

        [TestMethod]
        public async Task GetProfile_WhenCall_ShouldNotNull()
        {
            var actual = await _employeeRepository.GetProfileAsync();

            Assert.IsNotNull(actual);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _context.Dispose();
        }
    }
}
