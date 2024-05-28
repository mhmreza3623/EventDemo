using System.Text.Json.Serialization;

namespace Pms.Application.Dtos.ExternalService.Kariz.Requests;

public class AdanicApiBaseRequestModel
{
    /// <summary>
    /// شماره حساب
    /// </summary>
    [JsonPropertyName("account")]
    public string accountNumber { get; set; }

    /// <summary>
    /// نام چنل
    /// </summary>
    public string channel { get; set; }

    /// <summary>
    /// اطلاعات رمز گذاری شده حساب
    /// </summary>
    public string hash { get; set; }

    /// <summary>
    /// شناسه مرجع برای پیگیری تراکنش
    /// </summary>
    public string referenceId { get; set; }
}

public class AdanicBasePostModel
{
    /// <summary>
    /// نام چنل
    /// </summary>
    public string channel { get; set; }

    /// <summary>
    /// اطلاعات رمز گذاری شده حساب
    /// </summary>
    public string hash { get; set; }

    /// <summary>
    /// شناسه مرجع برای پیگیری تراکنش
    /// </summary>
    public string referenceId { get; set; }
}

