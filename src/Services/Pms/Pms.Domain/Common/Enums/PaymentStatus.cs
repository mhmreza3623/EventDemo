using System.ComponentModel;
using SharedKernel.Common;

namespace Pms.Domain.Common.Enums;

public class PaymentStatus : Enumerable<byte>
{
    public PaymentStatus(string code, string message) : base(code, message)
    {
    }

    public static PaymentStatus New = new("1", "جدید");
    public static PaymentStatus Pending = new("2", "منتظر ارسال به بانک");
    public static PaymentStatus Failed = new("3", "پرداخت ناموفق");
    public static PaymentStatus Succeed = new("4", "پرداخت موفق");

}