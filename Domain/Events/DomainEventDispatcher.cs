namespace Domain.Events;


using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

public abstract class DomainEventDispatcher
{
    public static void Dispatch(object domainEvent)
    {
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddConsole()
                .SetMinimumLevel(LogLevel.Information);
        });

        var logger = loggerFactory.CreateLogger(domainEvent.GetType().Name);
        logger.LogInformation($"[Event] {domainEvent.GetType().Name} dispatched");
    }
}
