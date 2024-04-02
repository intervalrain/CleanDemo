using CleanDemo.Domain.Common;

namespace CleanDemo.Domain.Users;

public class Subscription : Entity
{
    public SubscriptionType SubscriptionType { get; } = SubscriptionType.Unsubscribed!;

    public Subscription(SubscriptionType subscriptionType, Guid? id = null)
        : base(id ?? Guid.NewGuid()) 
    {
        SubscriptionType = subscriptionType;
    }

    public static readonly Subscription Canceled = new(SubscriptionType.Unsubscribed, Guid.Empty);

    private Subscription() { }
}

