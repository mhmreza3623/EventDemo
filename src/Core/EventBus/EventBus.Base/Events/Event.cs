namespace Core.EventBus.Events
{
    public record Event
    {
        public Event()
        {
            EventId = Guid.NewGuid();
            CreationDate = DateTime.Now;
        }

        public Guid EventId { get; private set; }
        public DateTime CreationDate { get; private set; }
        public Guid TenantId { get; set; }
        public virtual string EventName
        {
            get
            {
                return GetType().Name.Replace("Event", string.Empty);
            }
        }
    }
}
