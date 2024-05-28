namespace Core.EventBus.Events
{
    public class IntegrationEvent : Event
    {
        public IntegrationEvent(object entity)
        {
            this.Entity = entity;
        }

        public object Entity { get; set; }

        public override string EventName
        {
            get
            {
                return this.GetType().Name.Replace("IntegrationEvent", string.Empty);
            }
        }
    }
}
