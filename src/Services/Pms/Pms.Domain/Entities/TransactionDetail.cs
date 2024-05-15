using DataModels.Core.SqlModels;

namespace Pms.Domain.Entities;

public class TransactionDetail : BaseEntity
{
    public string Operation { get; set; }
    public string? Response { get; set; }
    public Transaction Transaction { get; set; }
}