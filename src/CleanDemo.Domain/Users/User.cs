using System;

using CleanDemo.Domain.Common;
using CleanDemo.Domain.Reminders;

using ErrorOr;

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
        throw new NotImplementedException();
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

    private User() { }
}

