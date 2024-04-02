using CleanDemo.Domain.Users;

using TestCommon.TestConstants;

namespace TestCommon.Subscriptions;

public static class SubscriptionFactory
{
    public static Subscription CreateSubsription(SubscriptionType subscriptionType = SubscriptionType.Unsubscribed, Guid? id =  null)
    {
        return new Subscription(
            subscriptionType,
            id ?? Constants.Subscription.Id);

    }
}

