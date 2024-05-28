namespace Pms.Application.Dtos.ExternalService.Kariz.Responses
{
    public class KarizProxyPayaTransferResponse : KarizBaseResponse
    {
        public string TranLink { get; set; }
        public string ChargeAmount1 { get; set; }
        public string ChargeAmount2 { get; set; }
        public string DebtorName { get; set; }
        public string DebtorFamilyName { get; set; }
        public string Branch { get; set; }
        public string PursuitCode { get; set; }
        public string AccountIban { get; set; }
        public string EconomicCode { get; set; }
        public string EconomicCodeN { get; set; }
        public string CreditorName { get; set; }
        public string CreditorFamilyName { get; set; }
        public string ExistPayId { get; set; }
        public string AccountStatus { get; set; }

        public string ErrorCode { get; set; }

        public string AlertCode { get; set; }
        public string MessageOut { get; set; }
    }
}
