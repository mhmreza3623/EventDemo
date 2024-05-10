namespace Core.EventBus.Masstransit
{
    public interface IMassTransitEventBusPipelineBehaviour
    {
        Task Execute(ConsumerPipelineContext context, PipelineOperation<ConsumerPipelineContext> next);
    }
}
