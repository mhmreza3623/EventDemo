using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Infrastructure.Persistence.MongoDb
{
    public static class MongoDbConfigSchema
    {
        public const string PaymentDataBase = "Dpk_Payment";
        public const string TransactionCollection = "Transactions";

        public const string ErrorLogDatabaseName = "Dpk_ErrorLog";
        public const string ErrorLogsCollection = "ErrorLogs";
    }
}
