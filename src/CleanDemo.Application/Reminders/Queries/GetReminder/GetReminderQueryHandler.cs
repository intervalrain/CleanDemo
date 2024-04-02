using CleanDemo.Domain.Reminders;

using ErrorOr;

using MediatR;

namespace CleanDemo.Application.Reminders.Queries.GetReminder;

public class GetReminderQueryHandler : IRequestHandler<GetReminderQuery, ErrorOr<Reminder>>
{
    public Task<ErrorOr<Reminder>> Handle(GetReminderQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

