using CleanDemo.Domain.Common;

namespace CleanDemo.Domain.Users.Events;

public record SubscriptionCanceledEvent(User User, Guid SubscriptionId) : IDomainEvent;