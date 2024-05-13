using DataBase.Core;

namespace Pms.Domain.Entities;

public class Account : BaseEntity
{
    public string Title { get; set; }
    public string DisplayTitle { get; set; }
    public string Identifier { get; set; }
    public string IsActive { get; set; }

    public Client Client { get; set; }
}