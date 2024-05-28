namespace Pms.Application.Dtos.ExternalService.Kariz.Requests;
public class TransferInquiryCommandRequestModel : AdanicApiBaseRequestModel
{

    /// <summary>
    /// شماره کارت
    /// Creditor account number
    /// 13 digit max lenght
    /// </summary>
    public string CreditorAccount { get; set; }
    /// <summary>
    /// حساب بدهکار حرف N را ارسال نمایید
    /// حساب بستانکار حرف C
    /// </summary>
    public string Indicator { get; set; }
    /// <summary>
    /// مبلغ تراکنش
    /// </summary>
    public decimal Amount { get; set; }
    /// <summary>
    /// Customer number
    /// 10 digit max lenght
    /// </summary>
    public string CustomerNo { get; set; }
    /// <summary>
    ///Refrence code for inquire the transfer
    /// </summary>
    public string Stamp { get; set; }
    /// <summary>
    /// Account's pin number
    /// </summary>
    public string Pin { get; set; }
}

