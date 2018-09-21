using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EMS.ApplicationCore.Specifications
{
    public class JobFunctionSpecification : BaseSpecification<MasterJobFunction>
    {
        public JobFunctionSpecification(Expression<Func<MasterJobFunction, bool>> filter)
            : base(filter)
        {
            AddInclude(x => x.Section);
            AddInclude(x => x.Section.Department);
        }
    }
}
