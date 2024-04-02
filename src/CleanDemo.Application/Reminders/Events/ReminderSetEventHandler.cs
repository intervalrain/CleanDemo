using CleanDemo.Domain.Users.Events;

using MediatR;

namespace CleanDemo.Application.Reminders.Events;

public class ReminderSetEventHandler : INotificationHandler<ReminderSetEvent>
{
    public Task Handle(ReminderSetEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

