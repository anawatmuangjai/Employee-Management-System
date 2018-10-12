using EMS.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EMS.ApplicationCore.Specifications
{
    public class AttendanceFilterSpecification : BaseSpecification<AttendanceModel>
    {
        public AttendanceFilterSpecification(int? departmentId, int? sectionId, int? shiftId)
            : base(x => (!departmentId.HasValue || x.DepartmentId == departmentId)
            && (!sectionId.HasValue || x.SectionId == sectionId)
            && (!shiftId.HasValue || x.ShiftId == shiftId))
        {
        }
    }
}
