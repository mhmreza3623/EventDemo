namespace Pms.Application.Common;

public class KarizConsts
{
    public const string AccountInfo = "account-info";
    public const string AccountBill = "account-bill";
    public const string AccountConditions = "account-conditions";
    public const string AccountControl = "account-control";
    public const string AccountDeposit = "account-deposit";
    public const string AccountBalance = "get-account-balance";
    public const string AccountTransfer = "account-transfer";
    public const string AccountWithdraw = "account-withdraw";
    public const string LedgerCredit = "ledger-credit";
    public const string LedgerDebit = "ledger-debit";
    public const string CustomerDetail = "customer-details";
    public const string CustomerDetailsInfo = "customer-detailed-info";
    public const string BlockingManagement = "blocking-management";
    public const string BlockingInquiry = "blocking-inquiry";
    public const string CloseAccount = "close-account";
    public const string UnblockAndDebit = "unblock-and-debit";
    public const string CustomerLoan = "customer-loan";
    public const string LoanBill = "loan-loan";
    public const string AccountRemoveStagnant = "account-remove-stagnant";
    public const string AccountSegregation = "account-segregation";
    public const string BlockingManagementSpecial = "blocking-management-special";
    public const string AccountSpecialInstruction = "account-special-instruction";
    public const string DefineNaturalCustomer = "define-natural-customer";
    public const string OpenAccount = "open-account";
    public const string SatnaTransfer = "satna-transfer";
    public const string ProxyPayaTransfer = "proxy-paya-transfer";
    public const string ProxyInquiry = "proxy-inquiry";
    public const string ReverseCardTransfer = "iso-reverse-card-transfer";
    public const string IsoCardBalance = "iso-card-balance";
    public const string IsoCardTransfer = "iso-card-transfer";
    public const string TransferInquiry = "transfer-inquiry";
    public const string ProxyPayInstallment = "proxy-pay-installment";
    public const string ShahabActualInquiry = "shahab-actual-inquiry";
    public const string LoanInfo = "loan-info-proxy";
    public const string LoanCustomerFacilityList = "loan-customer-facility-list";
    public const string IbanInquiryProxy = "iban-inquiry-proxy";
    public const string BlockingInquirySpecial = "blocking-inquiry-special";


    public static Dictionary<string, string> KarizAppSettings = new Dictionary<string, string>();

    public class Messages
    {
        public const string BadRequestMessage = "مقادیر ورودی با هم همخوانی ندارند لطفا داکیومنت مربوطه را مطالعه فرمایید";
        public const string PrivateKeyNotFound = "کلید خصوصی یافت نشد";
        public const string ExceptionSing = "هنگام امضا مشکلی رخ داده است";
    }
}