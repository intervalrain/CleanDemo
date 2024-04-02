using CleanDemo.Application.Common.Security.Request;
using CleanDemo.Domain.Reminders;

using ErrorOr;

namespace CleanDemo.Application.Reminders.Commands.SetReminder;

public record SetReminderCommand(Guid UserId, Guid SubscriptionId, string Text, DateTime DateTime) : IAuthorizableRequest<ErrorOr<Reminder>>;