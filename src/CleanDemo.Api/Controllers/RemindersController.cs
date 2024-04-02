using CleanDemo.Contracts.Reminders;

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
    public async Task<IActionResult> CreateReminder(CreateReminderRequest request)
    {
        var response = new ReminderResponse(request.Text, request.DateTime);
        return Ok(response);
    }

    [HttpGet("{reminderId:guid}")]
    public async Task<IActionResult> GetReminder(Guid reminderId)
    {
        var response = new ReminderResponse("text", DateTimeOffset.UtcNow);
        return Ok(response);

    }
}

