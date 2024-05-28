using Microsoft.Extensions.Options;
using Pms.Application.Dtos.ExternalService.Kariz.Requests;
using Pms.Application.Dtos.ExternalService.Kariz.Responses;
using Pms.Application.Interfaces;
using Pms.Domain.Common.SettingModels;
using SharedKernel.Common.HttpClient;

namespace Pms.Infrastructure.Services.ExternalServices.AdanicKariz
{
    public class KarizPaymentServiceProxy : HttpClientHelper, IKarizPaymentServiceProxy
    {
        private readonly AdanicKarizServiceSetting _karizServiceSetting;
        private const string ContentType = "application/json";

        public KarizPaymentServiceProxy(IOptions<AdanicKarizServiceSetting> settingManager)
        {
            _karizServiceSetting = settingManager.Value;
        }

        /// <summary>
        /// واریز به حساب
        /// </summary>
        /// <param name="accountVM"></param>
        /// <returns></returns>
        public async Task<KarizAccountDepositResponse> AccountDeposit(AccountDepositRequestModel model)
        {
            var response = await SendRequestAsJson<AccountDepositRequestModel, KarizAccountDepositResponse>(
                _karizServiceSetting.BaseApiUrl,
                _karizServiceSetting.AccountDeposit, model, HttpMethod.Post);

            return new KarizAccountDepositResponse();

        }

        /// <summary>
        /// انتقال حساب به حساب
        /// </summary>
        /// <param name="accountVM"></param>
        /// <returns></returns>
        public async Task<KarizAccountTransferResponse> AccountTransfer(AccountTransferRequestModel model)
        {
            var response = await SendRequestAsJson<AccountTransferRequestModel, KarizAccountTransferResponse>(
                _karizServiceSetting.BaseApiUrl,
                _karizServiceSetting.AccountTransfer, model, HttpMethod.Post);

            return response;
        }

        /// <summary>
        /// برداشت از حساب
        /// </summary>
        /// <param name="accountVM"></param>
        /// <returns></returns>
        public async Task<KarizAccountWithdrawResponse> AccountWithdraw(AccountWithdrawRequestModel model)
        {
            var response = await SendRequestAsJson<AccountWithdrawRequestModel, KarizAccountWithdrawResponse>(
                _karizServiceSetting.BaseApiUrl,
                _karizServiceSetting.AccountTransfer, model, HttpMethod.Post);

            return response;
        }

        /// <summary>
        /// استعلام شناسه شبا
        /// </summary>
        /// <param name="inquiryProxyVm"></param>

        public async Task<KarizIbanInquiryProxyResponse> IbanInquiryProxy(IbanInquiryProxyRequestModel model)
        {
            var response = await SendRequestAsJson<IbanInquiryProxyRequestModel, KarizIbanInquiryProxyResponse>(_karizServiceSetting.BaseApiUrl,
                _karizServiceSetting.IbanInquiryProxy + "iban", model, HttpMethod.Get);

            return response;

        }

        public async Task<KarizIsoCardTransferResponse> CardTransfer(CardTransferRequestModel model)
        {
            var response = await SendRequestAsJson<CardTransferRequestModel, KarizIsoCardTransferResponse>(_karizServiceSetting.BaseApiUrl,
                _karizServiceSetting.IsoCardTransfer, model, HttpMethod.Post);

            return response;
        }

        public async Task<KarizIsoReverseCardTransferResponse> IsoReverseCardTransfer(IsoReverseCardTransferRequestModel model)
        {
            var response = await SendRequestAsJson<IsoReverseCardTransferRequestModel, KarizIsoReverseCardTransferResponse>(
                _karizServiceSetting.BaseApiUrl,
                _karizServiceSetting.ReverseCardTransfer, model, HttpMethod.Post);

            return response;
        }

        /// <summary>
        /// بستانکار شدن حساب دفترکل
        /// </summary>
        /// <param name="ledgerCreditVm"></param>
        /// <returns></returns>
        public async Task<KarizLedgerCreditResponse> LedgerCredit(LedgerCreditRequestModel model)
        {
            var response = await SendRequestAsJson<LedgerCreditRequestModel, KarizLedgerCreditResponse>(_karizServiceSetting.BaseApiUrl,
                _karizServiceSetting.LedgerCredit, model, HttpMethod.Post);

            return response;
        }

        /// <summary>
        /// بدهکار شدن حساب دفتر کل
        /// </summary>
        /// <param name="ledgerDebitVm"></param>
        /// <returns></returns>
        public async Task<KarizLedgerDebitResponse> LedgerDebit(LedgerDebitRequestModel model)
        {
            var response = await SendRequestAsJson<LedgerDebitRequestModel, KarizLedgerDebitResponse>(_karizServiceSetting.BaseApiUrl,
                _karizServiceSetting.LedgerDebit, model, HttpMethod.Post);

            return response;
        }

        public async Task<KarizProxyInquiryResponse> ProxyInquiry(ProxyInquiryCommandRequestModel model)
        {
            var response = await SendRequestAsJson<ProxyInquiryCommandRequestModel, KarizProxyInquiryResponse>(_karizServiceSetting.BaseApiUrl,
                _karizServiceSetting.ProxyInquiry, model, HttpMethod.Get);

            return response;
        }

        /// <summary>
        /// انتقال پایا
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<KarizProxyPayaTransferResponse> ProxyPayaTransfer(ProxyPayaTransferRequestModel model)
        {
            var response = await SendRequestAsJson<ProxyPayaTransferRequestModel, KarizProxyPayaTransferResponse>(
                _karizServiceSetting.BaseApiUrl,
                _karizServiceSetting.ProxyPayaTransfer, model, HttpMethod.Post);

            return response;
        }


        /// <summary>
        /// انتقال ساتنا
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<KarizSatnaTransferResponse> SatnaTransfer(SatnaTransferRequestModel model)
        {
            var response = await SendRequestAsJson<SatnaTransferRequestModel, KarizSatnaTransferResponse>(_karizServiceSetting.BaseApiUrl,
                _karizServiceSetting.SatnaTransfer, model, HttpMethod.Post);

            return response;
        }

        public async Task<KarizTransferInquiryResponse> TransferInquiry(TransferInquiryCommandRequestModel transferInquiryModel)
        {
            var response = await SendRequestAsJson<TransferInquiryCommandRequestModel, KarizTransferInquiryResponse>(_karizServiceSetting.BaseApiUrl,
                _karizServiceSetting.TransferInquiry + transferInquiryModel.accountNumber, null, HttpMethod.Get);

            return response;
        }
    }
}
