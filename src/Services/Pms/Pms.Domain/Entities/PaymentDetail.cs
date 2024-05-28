using Pms.Domain.Common.Enums;
using SharedKernel.Common.SqlModels;

namespace Pms.Domain.Entities;

public class PaymentDetail : BaseEntity
{
    public string Request { get; set; }
    public string? Response { get; set; }
    public Payment Payment { get; set; }
    public PaymentLogStatus Status { get; set; }
}