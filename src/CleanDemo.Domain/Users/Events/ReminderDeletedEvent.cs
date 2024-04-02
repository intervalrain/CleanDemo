using CleanDemo.Domain.Common;

namespace CleanDemo.Domain.Users.Events;

public record ReminderDeletedEvent(Guid ReminderId) : IDomainEvent;