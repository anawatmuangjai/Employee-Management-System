using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EMS.ApplicationCore.Specifications
{
    public class AuthoritySpecification : BaseSpecification<MasterAccountAuthority>
    {
        public AuthoritySpecification(Expression<Func<MasterAccountAuthority, bool>> filter)
            : base(filter)
        {
            AddInclude(x => x.Account);
            AddInclude(x => x.Authority);
        }
    }
}
