namespace Core.EventBus.Events
{
    public class DomainEvent : Event
    {
        public object Entity { get; }

        public DomainEvent(object entity)
        {
            Entity = entity;
        }

        public override string EventName
        {
            get
            {
                return this.GetType().Name.Replace("DomainEvent", string.Empty);
            }
        }
    }
}
