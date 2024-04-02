using CleanDemo.Application.Common.Interfaces;
using CleanDemo.Domain.Reminders;

using ErrorOr;

using MediatR;

namespace CleanDemo.Application.Reminders.Commands.SetReminder;

public class CreateReminderCommandHandler : IRequestHandler<SetReminderCommand, ErrorOr<Reminder>>
{
    private readonly IUsersRepository _usersRepository;

    public CreateReminderCommandHandler(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<ErrorOr<Reminder>> Handle(SetReminderCommand request, CancellationToken cancellationToken)
    {
        var reminder = new Reminder(request.UserId, request.SubscriptionId, request.Text, request.DateTime);

        var user = await _usersRepository.GetBySubscriptionIdAsync(request.SubscriptionId, cancellationToken);

        if (user is null)
        {
            return Error.Unexpected(description: "User corresponding to current user not found");
        }

        var result = user.SetReminder(reminder);

        if (result.IsError)
        {
            return result.Errors;
        }

        await _usersRepository.UpdateAsync(user, cancellationToken);

        return reminder;
    }
}

