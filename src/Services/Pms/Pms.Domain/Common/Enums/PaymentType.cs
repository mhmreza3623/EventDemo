using SharedKernel.Common;
using System.ComponentModel;

namespace Pms.Domain.Common.Enums;

public class PaymentType : Enumerable<byte>
{
    public PaymentType(string code, string message) : base(code, message)
    {
    }

    public static PaymentType AccountDeposit = new("1", "واریز به حساب");
    public static PaymentType AccountTransfer = new("2", "انتقال حساب به حساب");
    public static PaymentType AccountWithdraw = new("3", "برداشت از حساب");
    public static PaymentType SatnaTransfer = new("4", "انتقال وجه ساتنا");
    public static PaymentType ProxyPayaTransfer = new("5", "انتقال وجه پایا از طریق پروکسی");

}