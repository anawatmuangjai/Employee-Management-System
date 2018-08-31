using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EMS.ApplicationCore.Specifications
{
    public class AttendanceSpecification : BaseSpecification<Attendance>
    {
        public AttendanceSpecification(Expression<Func<Attendance, bool>> filter) : base(filter)
        {
            AddInclude(x => x.Employee);
            AddInclude(x => x.Employee.EmployeeState);
            AddInclude(x => x.Employee.EmployeeState.Level);
            AddInclude(x => x.Employee.EmployeeState.Shift);
            AddInclude(x => x.Employee.EmployeeState.Department);
            AddInclude(x => x.Employee.EmployeeState.Section);
            AddInclude(x => x.Employee.EmployeeState.Position);
            AddInclude(x => x.Employee.EmployeeState.JobFunction);
            AddInclude(x => x.Employee.EmployeeState.BusStation);
        }
    }
}
