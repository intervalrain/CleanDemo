using CleanDemo.Application.Common.Interfaces;
using CleanDemo.Domain.Users.Events;

using MediatR;

namespace CleanDemo.Application.Reminders.Events;

public class ReminderSetEventHandler : INotificationHandler<ReminderSetEvent>
{
    private readonly IRemindersRepository _reminderRepository;

    public ReminderSetEventHandler(IRemindersRepository reminderRepository )
    {
        _reminderRepository = reminderRepository;
    }

    public async Task Handle(ReminderSetEvent notification, CancellationToken cancellationToken)
    {
        await _reminderRepository.AddAsync(notification.Reminder, cancellationToken);
    }
}

