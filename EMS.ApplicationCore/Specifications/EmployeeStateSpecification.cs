using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EMS.ApplicationCore.Specifications
{
    public class EmployeeStateSpecification : BaseSpecification<EmployeeState>
    {
        public EmployeeStateSpecification(Expression<Func<EmployeeState, bool>> filter)
            : base(filter)
        {
            AddInclude(x => x.JobFunction);
            AddInclude(x => x.JobFunction.Section);
            AddInclude(x => x.JobFunction.Section.Department);
            AddInclude(x => x.Shift);
        }
    }
}
