using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EMS.ApplicationCore.Specifications
{
    public class EmployeeSkillSpecification : BaseSpecification<EmployeSkills>
    {
        public EmployeeSkillSpecification(Expression<Func<EmployeSkills, bool>> filter) 
            : base(filter)
        {
            AddInclude(x => x.Skill);
            AddInclude(x => x.Skill.SkillGroup);
            AddInclude(x => x.Skill.SkillType);
        }
    }
}
