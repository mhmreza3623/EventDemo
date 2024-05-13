namespace Core.EventBus.Events
{
    public class IntegrationEvent : Event
    {
        public IntegrationEvent(Guid clientId)
        {
            this.TenantId = clientId;
        }
        public override string EventName
        {
            get
            {
                return this.GetType().Name.Replace("IntegrationEvent", string.Empty);
            }
        }
    }
}
