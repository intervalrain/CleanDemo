using CleanDemo.Domain.Common;
using CleanDemo.Domain.Reminders;

namespace CleanDemo.Domain.Users.Events;

public record ReminderSetEvent(Reminder Reminder) : IDomainEvent;