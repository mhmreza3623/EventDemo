using System.ComponentModel;

namespace Pms.Domain.Enums;

public enum PaymentStatus : byte
{
    [Description("جدید")]New=1,
    [Description("منتظر ارسال به بانک")] Pending =2,
    [Description("برگشت از بانک")]BackFromBank=3,
    [Description("پرداخت ناموفق")]Failed=4,
    [Description("پرداخت موفق")] Paid =5,
}