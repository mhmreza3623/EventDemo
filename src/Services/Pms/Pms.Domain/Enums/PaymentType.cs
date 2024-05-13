using System.ComponentModel;

namespace Pms.Domain.Enums;

public enum PaymentType
{
    [Description("واریز به حساب")]
    AccountDeposit = 1,
    [Description("انتقال حساب به حساب")]
    AccountTransfer = 2,
    [Description("برداشت از حساب")]
    AccountWithdraw = 3,
    [Description("انتقال وجه ساتنا")]
    SatnaTransfer = 4,
    [Description("انتقال وجه پایا از طریق پروکسی")]
    ProxyPayaTransfer = 5,

}