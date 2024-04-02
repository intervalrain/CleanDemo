using CleanDemo.Domain.Common;

namespace CleanDemo.Domain.Users.Events;

public record ReminderDismissedEvent(Guid ReminderId) : IDomainEvent;