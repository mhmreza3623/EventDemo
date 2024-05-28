using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.EventBus.Events;

namespace SharedKernel.Common.SqlModels
{
    public class BaseEntity
    {
        public List<DomainEvent> Events;

        public BaseEntity()
        {
            Events = new();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public Guid UxId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public bool IsDeleted { get; set; }
        
    }
}
