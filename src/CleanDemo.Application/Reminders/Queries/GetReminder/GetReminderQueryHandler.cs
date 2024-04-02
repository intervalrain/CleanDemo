using CleanDemo.Application.Common.Interfaces;
using CleanDemo.Domain.Reminders;

using ErrorOr;

using MediatR;

namespace CleanDemo.Application.Reminders.Queries.GetReminder;

public class GetReminderQueryHandler : IRequestHandler<GetReminderQuery, ErrorOr<Reminder>>
{
    private readonly IRemindersRepository _remindersRepository;

    public GetReminderQueryHandler(IRemindersRepository remindersRepository)
    {
        _remindersRepository = remindersRepository;
    }

    public async Task<ErrorOr<Reminder>> Handle(GetReminderQuery request, CancellationToken cancellationToken)
    {
        var reminder = await _remindersRepository.GetByIdAsync(request.ReminderId, cancellationToken);

        if (reminder?.UserId != request.UserId)
        {
            return Error.NotFound(description: "Reminder not found");
        }

        return reminder;
    }
}

