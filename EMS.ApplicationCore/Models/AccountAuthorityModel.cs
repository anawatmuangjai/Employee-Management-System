using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.ApplicationCore.Models
{
    public class AccountAuthorityModel
    {
        public int AccountId { get; set; }
        public int AuthorityId { get; set; }

        public AccountModel Account { get; set; }
        public AuthorityModel Authority { get; set; }
    }
}
