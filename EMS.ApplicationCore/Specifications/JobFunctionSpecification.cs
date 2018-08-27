using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EMS.ApplicationCore.Specifications
{
    public class JobFunctionSpecification : BaseSpecification<MasterJobFunction>
    {
        public JobFunctionSpecification()
            : base(x => x.JobFunctionId > 0)
        {
            AddInclude(x => x.JobTitle);
        }
    }
}
