using System;
using System.Collections.Generic;

namespace EMS.Domain.Entities
{
    public partial class MasterAccount : BaseEntity
    {
        public MasterAccount()
        {
            EmployeeAccount = new HashSet<EmployeeAccount>();
            MasterAccountAuthority = new HashSet<MasterAccountAuthority>();
        }

        public int AccountId { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime ChangeDate { get; set; }

        public ICollection<EmployeeAccount> EmployeeAccount { get; set; }
        public ICollection<MasterAccountAuthority> MasterAccountAuthority { get; set; }
    }
}
