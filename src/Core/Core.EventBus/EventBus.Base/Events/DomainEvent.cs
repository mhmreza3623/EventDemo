namespace Core.EventBus.Events
{
    public class DomainEvent : Event
    {
        public string Value { get; set; }
        public override string EventName => this.GetType().Name.Replace("DomainEvent", string.Empty);
    }
}
