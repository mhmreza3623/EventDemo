
using SharedKernel.Common;

namespace Pms.Domain.Common.Enums;

public class PaymentProvider : Enumerable<byte>
{
    public PaymentProvider(string code, string message) : base(code, message)
    {
    }

    public static PaymentProvider Z = new("1", "جدید");

}