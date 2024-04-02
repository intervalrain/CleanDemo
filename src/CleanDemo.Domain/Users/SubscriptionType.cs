namespace CleanDemo.Domain.Users;

public enum SubscriptionType
{
    Unsubscribed = -1,
    Basic = 0,
    Pro = 1
}

public static class SubscriptionTypeExtension
{
    public static int GetMaxDailyReminders(this SubscriptionType subscriptionType)
    {
        return subscriptionType switch
        {
            SubscriptionType.Basic => 3,
            SubscriptionType.Pro => int.MaxValue,
            _ => throw new InvalidOperationException()
        };
    }
}
