using CleanDemo.Domain.Users;

using ErrorOr;

using FluentAssertions;

using TestCommon.Reminders;
using TestCommon.Subscriptions;
using TestCommon.Users;

namespace CleanDemo.Domain.UnitTests.Users;

public class UserTests
{
    [Theory]
    [MemberData(nameof(ListSubscriptionWithLimit))]
    public void SetReminder_WhenMoreThenSubscriptionAllows_ShouldFail(SubscriptionType subscriptionType)
    {
        // Arrange
        var subscription = SubscriptionFactory.CreateSubsription(subscriptionType: subscriptionType);
        var user = UserFactory.CreateUser(subscription: subscription);
        var reminders = Enumerable.Range(0, subscriptionType.GetMaxDailyReminders() + 1)
            .Select(_ => ReminderFactory.CreateReminder(id: Guid.NewGuid(), subscriptionId: subscription.Id));

        // Act
        var setReminderResults = reminders.Select(user.SetReminder).ToList();

        // Assert
        var allButLastSetReminderResults = setReminderResults[..^1];
        allButLastSetReminderResults.Should().AllSatisfy(
            setReminderResult => setReminderResult.Value.Should().Be(Result.Success));

        var lastReminder = setReminderResults.Last();
        lastReminder.IsError.Should().BeTrue();
        lastReminder.FirstError.Should().Be(UserErrors.CannotCreateMoreRemindersThanSubscriptionAllows);
    }


    public static TheoryData<SubscriptionType> ListSubscriptionWithLimit()
    {
        TheoryData<SubscriptionType> theoryData = new();

        var types = Enum.GetValues<SubscriptionType>();
        theoryData.AddRange(types.Except(new[] { SubscriptionType.Pro, SubscriptionType.Unsubscribed }).ToArray());

        return theoryData;
    }
}

