namespace Pms.Infrastructure.Persistence.EF
{
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
