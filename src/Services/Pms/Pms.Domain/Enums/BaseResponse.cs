using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms.Domain.Enums
{
    public class BaseResponse 
    {
        public BaseResponse(string message, string code, bool succeed )
        {
            Message = message;
            Code = code;
            Succeed = succeed;
        }

        public bool Succeed { get; }
        public string Code { get; }
        public string Message { get; }
    }

    public class FailedResponse: BaseResponse
    {
        public FailedResponse(string message, string code) : base(message, code, false)
        {
        }

        public static FailedResponse CreateTransactionLogError = new("1001", "خطا در ثبت تراکنش");
    }

    public class SucceedResponse : BaseResponse
    {
        public SucceedResponse(string? message) : base(message, string.Empty, true)
        {
        }
    }
}
