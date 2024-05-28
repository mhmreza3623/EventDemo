namespace Core.EventBus.Events
{
    public class Event
    {
        public Event()
        {
            EventId = Guid.NewGuid();
            CreationDate = DateTime.Now;
        }

        public Guid EventId { get; private set; }
        public DateTime CreationDate { get; private set; }

        public virtual string EventName
        {
            get
            {
                return GetType().Name.Replace("Event", string.Empty);
            }
        }
    }
}
