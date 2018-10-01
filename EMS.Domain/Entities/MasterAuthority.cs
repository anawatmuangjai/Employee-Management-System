using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class MasterAuthority : BaseEntity
    {
        public MasterAuthority()
        {
            MasterAccountAuthority = new HashSet<MasterAccountAuthority>();
        }

        public int AuthorityId { get; set; }
        public string AuthorityName { get; set; }

        public ICollection<MasterAccountAuthority> MasterAccountAuthority { get; set; }
    }
}
