using CleanDemo.Application.SubcutaneousTests.Common;

using ErrorOr;

using FluentAssertions;

using MediatR;

using TestCommon.Reminders;

namespace CleanDemo.Application.SubcutaneousTests.Reminders.Commands.SetReminder;

[Collection(WebAppFactoryCollection.CollectionName)]
public class SetReminderTests
{
    private readonly IMediator _mediator;

    public SetReminderTests(WebAppFactory webAppFactory)
    {
        _mediator = webAppFactory.CreateMediator();
    }

    [Fact]
    public async Task SetReminder_WhenSubscriptionDoesNotExists_ShouldReturnNotFound()
    {
        // Arrange
        var command = ReminderCommandFactory.CreateSetReminderCommand();

        // Act
        var result = await _mediator.Send(command);

        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Type.Should().Be(ErrorType.NotFound);
    }
}

