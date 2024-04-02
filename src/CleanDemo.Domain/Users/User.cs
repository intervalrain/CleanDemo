using System;

using CleanDemo.Domain.Common;
using CleanDemo.Domain.Reminders;
using CleanDemo.Domain.Users.Events;

using ErrorOr;

using Throw;

namespace CleanDemo.Domain.Users;

public class User : Entity
{
    private readonly Calendar? _calendar = null!;
    private readonly List<Guid> _reminderIds = new();
    private readonly List<Guid> _dismissedReminderIds = new();

    public string FirstName { get; } = null!;
    public string LastName { get; } = null!;
    public string Email { get; } = null!;
    public Subscription Subscription { get; private set; } = null!;

    public User(
        Guid id,
        string firstName,
        string lastName,
        string email,
        Subscription subscription,
        Calendar? calendar = null)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Subscription = subscription;
        _calendar = calendar ?? Calendar.Empty();
    }

    public ErrorOr<Success> SetReminder(Reminder reminder)
    {
        if (Subscription == Subscription.Canceled)
        {
            return Error.NotFound(description: "Subscription not found");
        }

        reminder.SubscriptionId.Throw().IfNotEquals(Subscription.Id);

        if (HasReachedDailyReminderLimit(reminder.DateTime))
        {
            return UserErrors.CannotCreateMoreRemindersThanSubscriptionAllows;
        }

        _calendar.IncrementEventCount(reminder.Date);
        _reminderIds.Add(reminder.Id);
        _domainEvents.Add(new ReminderSetEvent(reminder));

        return Result.Success;
    }

    public ErrorOr<Success> DismissReminder(Guid reminderId)
    {
        throw new NotImplementedException();
    }

    public ErrorOr<Success> CancelSubscription(Guid subscriptionId)
    {
        throw new NotImplementedException();
    }

    public ErrorOr<Success> DeleteReminder(Reminder reminder)
    {
        throw new NotImplementedException();
    }

    public void DeleteAllReminders()
    {
        throw new NotImplementedException();
    }

    private bool HasReachedDailyReminderLimit(DateTime dateTime)
    {
        var dailyReminderCount = _calendar.GetNumEventsOnDay(dateTime.Date);

        return dailyReminderCount >= Subscription.SubscriptionType.GetMaxDailyReminders();
    }

    private User() { }
}

