using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class MasterLocationGroup : BaseEntity
    {
        public MasterLocationGroup()
        {
            MasterLocation = new HashSet<MasterLocation>();
        }

        public int LocationGroupId { get; set; }
        public string LocationGroupName { get; set; }

        public ICollection<MasterLocation> MasterLocation { get; set; }
    }
}
