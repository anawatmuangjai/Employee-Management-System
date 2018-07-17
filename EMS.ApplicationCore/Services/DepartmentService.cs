using EMS.ApplicationCore.Interfaces.Repositories;
using EMS.ApplicationCore.Interfaces.Services;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.ApplicationCore.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<MasterDepartment> _departmentRepository;

        public DepartmentService(IRepository<MasterDepartment> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }


    }
}
