using CleanDemo.Domain.Reminders;

using ErrorOr;

using MediatR;

namespace CleanDemo.Application.Reminders.Commands.SetReminder;

public class CreateReminderCommandHandler : IRequestHandler<SetReminderCommand, ErrorOr<Reminder>>
{
    public Task<ErrorOr<Reminder>> Handle(SetReminderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

