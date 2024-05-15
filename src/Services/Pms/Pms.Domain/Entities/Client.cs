using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using DataModels.Core.SqlModels;

namespace Pms.Domain.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Ips { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
