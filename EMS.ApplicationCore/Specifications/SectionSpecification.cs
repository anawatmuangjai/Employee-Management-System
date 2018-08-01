using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EMS.ApplicationCore.Specifications
{
    public class SectionSpecification : BaseSpecification<MasterSection>
    {
        public SectionSpecification(string sectionName)
            : base(s => s.SectionName.Contains(sectionName))
        {
            AddInclude(s => s.Department);
        }
    }
}
