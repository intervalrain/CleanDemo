using CleanDemo.Domain.Common;

using MediatR;

using Microsoft.AspNetCore.Http;

namespace CleanDemo.Infrastructure.Common;

public class EventualConsistencyMiddleware
{
    public const string DomainEventsKey = "DomainEventsKey";

    private readonly RequestDelegate _next;

    public EventualConsistencyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IPublisher publisher, AppDbContext dbContext)
    {
        var transaction = dbContext.Database.BeginTransaction();
        context.Response.OnCompleted(async () =>
        {
            try
            {
                if (context.Items.TryGetValue(DomainEventsKey, out var value) && value is Queue<IDomainEvent> events)
                {
                    while (events.TryDequeue(out var @event))
                    {
                        await publisher.Publish(@event);
                    }
                }

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
            }
            finally
            {
                await transaction.DisposeAsync();
            }
        });

        await _next(context);
    }
}

