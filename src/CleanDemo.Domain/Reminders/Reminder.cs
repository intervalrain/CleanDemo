using CleanDemo.Domain.Common;

using ErrorOr;

namespace CleanDemo.Domain.Reminders;

public class Reminder : Entity
{
    public Guid UserId { get; }
    public Guid SubscriptionId { get; }
    public string Text { get; }
    public DateTime DateTime { get; }
    public DateOnly Date => DateOnly.FromDateTime(DateTime.Date);

    public bool IsDismissed { get; private set; }

    public Reminder(
        Guid userId,
        Guid subscriptionId,
        string text,
        DateTime dateTime,
        Guid? id = null)
        : base(id ?? Guid.NewGuid())
    {
        UserId = userId;
        SubscriptionId = subscriptionId;
        Text = text;
        DateTime = dateTime;
    }

    public ErrorOr<Success> Dismiss()
    {
        throw new NotImplementedException();
    }

    private Reminder()
    {
    }
}