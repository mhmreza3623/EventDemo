using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Infrastructure.Persistence.EF
{
    internal class PaymentDbContextSchema
    {
        public static class PaymentStatics
        {
            public const string SchemaName = "Payment";

            public const string TransactionTableName = "Transactions";
            public const string TransactionDetailsTableName = "TransactionDetails";
            public const string ClientTableName = "Clients";
            public const string AccountTableName = "Accounts";

        }
    }
}
