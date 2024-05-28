using SharedKernel.Common;

namespace Pms.Domain.Common.Enums;

public class PaymentLogStatus : Enumerable<byte>
{
    public PaymentLogStatus(string code, string message) : base(code, message)
    {
    }

    public static PaymentLogStatus New = new("1", "جدید");
    public static PaymentLogStatus Wait = new("2", "منتظر ارسال به بانک");
    public static PaymentLogStatus ReturnFromBank = new("3", "برگشت از بانک");
    public static PaymentLogStatus Failed = new("4", "ناموفق");
    public static PaymentLogStatus Succeed = new("5", "ناموفق");
}