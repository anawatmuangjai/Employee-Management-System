using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class MasterAccountAuthority : BaseEntity
    {
        public int AccountId { get; set; }
        public int AuthorityId { get; set; }

        public MasterAccount Account { get; set; }
        public MasterAuthority Authority { get; set; }
    }
}
