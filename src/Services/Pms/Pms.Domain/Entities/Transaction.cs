using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels.Core.SqlModels;
using Pms.Domain.Enums;

namespace Pms.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public PaymentStatus Status { get; set; }
        public PaymentType Type { get; set; }
        public decimal Amount { get; set; }
        public string ReferenceId { get; set; }
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientToken { get; set; }
        public int ClientIp { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string MetaData { get; set; }

        public ICollection<TransactionDetail> TransactionDetails { get; set; }
    }
}
