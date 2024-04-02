using CleanDemo.Domain.Common;

namespace CleanDemo.Domain.Reminders;

public class Reminder : Entity
{
    public Guid UserId { get; }
    public Guid SubscriptionId { get; }
    public string Text { get; }
    public DateTime DateTime { get; }
    public DateOnly Date => DateOnly.FromDateTime(DateTime.Date);

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

    private Reminder()
    {
    }
}