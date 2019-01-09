using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EMS.ApplicationCore.Specifications
{
    public class CalendarSpecification : BaseSpecification<MasterShiftCalendar>
    {
        public CalendarSpecification(Expression<Func<MasterShiftCalendar, bool>> filter)
            : base(filter)
        {
            AddInclude(x => x.Shift);
        }
    }
}
