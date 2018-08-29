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
            AddInclude(e => e.EmployeeState);
            AddInclude(e => e.EmployeeState.Department);
            AddInclude(e => e.EmployeeState.Section);
            AddInclude(e => e.EmployeeState.Shift);
            AddInclude(e => e.EmployeeState.Level);
            AddInclude(e => e.EmployeeState.Position);
            AddInclude(e => e.EmployeeState.JobFunction);
            AddInclude(e => e.EmployeeState.BusStation);
        }
    }
}
