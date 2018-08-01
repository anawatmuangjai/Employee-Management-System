using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EMS.ApplicationCore.Specifications
{
    public class EmployeeFilterSpecification : BaseSpecification<Employee>
    {
        public EmployeeFilterSpecification(string employeeId)
            : base(e => e.EmployeeId == employeeId)
        {
            AddInclude(e => e.EmployeeAddress);
        }
    }
}
