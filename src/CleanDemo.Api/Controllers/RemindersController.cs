using CleanDemo.Application.Reminders.Commands.SetReminder;
using CleanDemo.Application.Reminders.Queries.GetReminder;
using CleanDemo.Contracts.Reminders;
using CleanDemo.Domain.Reminders;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace CleanDemo.Api.Controllers;

[Route("[Controller]")]
public class RemindersController : ApiController
{
    private readonly ISender _mediator;

    public RemindersController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateReminder(Guid userId, Guid subscriptionId, CreateReminderRequest request)
    {
        var command = new SetReminderCommand(userId, subscriptionId, request.Text, request.DateTime.UtcDateTime);

        var result = await _mediator.Send(command);

        return result.Match(
            reminder => CreatedAtAction(
                actionName: nameof(GetReminder),
                routeValues: new { UserId = userId, SubscriptionId = subscriptionId, ReminderId = reminder.Id },
                value: ToDto(reminder)),
            Problem);
    }

    [HttpGet("{reminderId:guid}")]
    public async Task<IActionResult> GetReminder(Guid userId, Guid subscriptionId, Guid reminderId)
    {
        var query = new GetReminderQuery(userId, subscriptionId, reminderId);

        var result = await _mediator.Send(query);

        return result.Match(
            reminder => Ok(ToDto(reminder)), 
            Problem);
    }

    private ReminderResponse ToDto(Reminder reminder) => new ReminderResponse(reminder.Id, reminder.Text, reminder.DateTime, reminder.IsDismissed);
}

