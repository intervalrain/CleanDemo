using CleanDemo.Domain.Common;
using CleanDemo.Domain.Reminders;
using CleanDemo.Domain.Users;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CleanDemo.Infrastructure.Common;

public class AppDbContext : DbContext
{
    private readonly DbContextOptions _options;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IPublisher _publisher;

    public DbSet<Reminder> Reminders { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!; 

    public AppDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor, IPublisher publisher)
        : base(options)
    {
        _options = options;
        _httpContextAccessor = httpContextAccessor;
        _publisher = publisher;
    }

    public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var domainEvents = ChangeTracker.Entries<Entity>()
            .Select(entry => entry.Entity.PopDomainEvents())
            .SelectMany(x => x)
            .ToList();

        if (IsUserWaitingOnline())
        {
            AddDomainEventsToOfflineProcessingQueue(domainEvents);
            return await base.SaveChangesAsync(cancellationToken);
        }

        await PublishDomainEvents(domainEvents);
        return await base.SaveChangesAsync(cancellationToken); 
    }

    private void AddDomainEventsToOfflineProcessingQueue(List<IDomainEvent> domainEvents)
    {
        var queue = _httpContextAccessor.HttpContext.Items.TryGetValue(EventualConsistencyMiddleware.DomainEventsKey, out var value) &&
            value is Queue<IDomainEvent> events
            ? events
            : new();

        domainEvents.ForEach(queue.Enqueue);
        _httpContextAccessor.HttpContext.Items[EventualConsistencyMiddleware.DomainEventsKey] = queue;
    }

    private async Task PublishDomainEvents(List<IDomainEvent> domainEvents)
    {
        foreach (var @event in domainEvents)
        {
            await _publisher.Publish(@event);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    private bool IsUserWaitingOnline() => _httpContextAccessor.HttpContext is not null;
}

