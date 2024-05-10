namespace Core.EventBus.Events
{
    public class IntegrationEvent : Event
    {
        public IntegrationEvent(Guid tenantId)
        {
            this.TenantId = tenantId;
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
