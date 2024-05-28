

using SharedKernel.Common;

namespace Pms.Domain.Common.Enums;

public class ErrorCodes : Enumerable<byte>
{
    public ErrorCodes(string code, string message) : base(code, message)
    {
    }

    public static ErrorCodes NotFoundClient = new("1001", "کلاینت یافت نشد");
    public static ErrorCodes CreateUserFailed = new("1002", "ثبت کاربر ناموفق بود");
    public static ErrorCodes DuplicateUser = new("1003", " کاربر تکرای است");
    public static ErrorCodes InvalidClientId = new("1004", " شناسه سامانه اشتباه است");
    public static ErrorCodes InvalidToken = new("1005", " توکن نامعتبر است");
    public static ErrorCodes InvalidUser = new("1006", " کاربر نامعتبر است");
}