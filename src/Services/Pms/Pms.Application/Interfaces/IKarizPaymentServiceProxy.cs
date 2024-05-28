using Pms.Application.Dtos.ExternalService.Kariz.Requests;
using Pms.Application.Dtos.ExternalService.Kariz.Responses;

namespace Pms.Application.Interfaces;

public interface IKarizPaymentServiceProxy
{
    /// <summary>
    /// واریز به حساب
    /// </summary>
    /// <param name="accountVM"></param>
    /// <returns></returns>
    Task<KarizAccountDepositResponse> AccountDeposit(AccountDepositRequestModel model);

    /// <summary>
    /// انتقال حساب به حساب
    /// </summary>
    /// <param name="accountVM"></param>
    /// <returns></returns>
    Task<KarizAccountTransferResponse> AccountTransfer(AccountTransferRequestModel model);

    /// <summary>
    /// برداشت از حساب
    /// </summary>
    /// <param name="accountVM"></param>
    /// <returns></returns>
    Task<KarizAccountWithdrawResponse> AccountWithdraw(AccountWithdrawRequestModel model);

    /// <summary>
    /// استعلام شناسه شبا
    /// </summary>
    /// <param name="inquiryProxyVm"></param>
    Task<KarizIbanInquiryProxyResponse> IbanInquiryProxy(IbanInquiryProxyRequestModel model);

    Task<KarizIsoCardTransferResponse> CardTransfer(CardTransferRequestModel model);

    Task<KarizIsoReverseCardTransferResponse> IsoReverseCardTransfer(IsoReverseCardTransferRequestModel model);

    /// <summary>
    /// بستانکار شدن حساب دفترکل
    /// </summary>
    /// <param name="ledgerCreditVm"></param>
    /// <returns></returns>
    Task<KarizLedgerCreditResponse> LedgerCredit(LedgerCreditRequestModel model);

    /// <summary>
    /// بدهکار شدن حساب دفتر کل
    /// </summary>
    /// <param name="ledgerDebitVm"></param>
    /// <returns></returns>
    Task<KarizLedgerDebitResponse> LedgerDebit(LedgerDebitRequestModel model);

    Task<KarizProxyInquiryResponse> ProxyInquiry(ProxyInquiryCommandRequestModel model);

    /// <summary>
    /// انتقال پایا
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<KarizProxyPayaTransferResponse> ProxyPayaTransfer(ProxyPayaTransferRequestModel model);

    /// <summary>
    /// انتقال ساتنا
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<KarizSatnaTransferResponse> SatnaTransfer(SatnaTransferRequestModel model);

    Task<KarizTransferInquiryResponse> TransferInquiry(TransferInquiryCommandRequestModel transferInquiryModel);
}