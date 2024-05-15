using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Core
{
    public static class DataBaseConstantKeys
    {
        public const string DefaultSqlConnectionKey = "DefaultSqlConnection";
        public const string DefaultMongoConnectionKey = "ConnectionString";
        public const string DefaultMongoDataBaseKey = "DatabaseName";
        public const string DefaultErrorLogTable= "ErrorLogs";

        public const string AuditLogsDataBaseName = "Dpk_AuditLogs";
        public const string AuditLogsDataCollection = "AuditLogDataCollection";
    }

    public static class LogStatics
    {
        public const string SchemaName = "Log";
        public const string ErrorLogTableName = "ErrorLogs";

    }
    public static class PaymentStatics
    {
        public const string SchemaName = "Payment";
        public const string TransactionTableName = "Transactions";
        public const string TransactionDetailsTableName = "TransactionDetails";
        public const string ClientTableName = "Clients";
        public const string AccountTableName = "Accounts";
    }
}
