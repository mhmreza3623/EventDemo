using Microsoft.Extensions.Logging;

namespace Core.EventBus.Masstransit
{
    public class MassTransitIdemptoncyPipelineBehavior : IMassTransitEventBusPipelineBehaviour
    {
        private readonly ILogger<MassTransitIdemptoncyPipelineBehavior> _logger;

        public MassTransitIdemptoncyPipelineBehavior(ILogger<MassTransitIdemptoncyPipelineBehavior> logger)
        {
            _logger = logger;
        }
        public async Task Execute(ConsumerPipelineContext context, PipelineOperation<ConsumerPipelineContext> next)
        {
            //if (await _idempotencyManager.ExistAsync(context.Event.EventId))
            //{
            //    _logger.LogInformation("Event already handled!", context.Event);
            //    return;
            //}

            //using (var session = await _mongoContext.StartSessionAsync())
            //{
            //    session.StartTransaction();
            //    try
            //    {
            //        await next.Invoke(context);
            //        await _idempotencyManager.SetHandledAsync(context.Event);

            //        await _mongoContext.CommitTransactionAsync(session);
            //    }
            //    catch
            //    {
            //        if (session.IsInTransaction)
            //            await _mongoContext.AbortTransactionAsync(session);
            //        throw;
            //    }
            //}

            _logger.LogInformation($"Event handled", context.Event);
        }
    }
}
