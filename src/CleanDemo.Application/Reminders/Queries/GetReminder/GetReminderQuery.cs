using CleanDemo.Application.Common.Security.Permissions;
using CleanDemo.Application.Common.Security.Policies;
using CleanDemo.Application.Common.Security.Request;
using CleanDemo.Domain.Reminders;

using ErrorOr;

namespace CleanDemo.Application.Reminders.Queries.GetReminder;

[Authorize(Permissions = Permission.Reminder.Get, Policies = Policy.SelfOrAdmin)]
public record GetReminderQuery(Guid UserId, Guid SubscriptionId, Guid ReminderId) : IAuthorizableRequest<ErrorOr<Reminder>>;