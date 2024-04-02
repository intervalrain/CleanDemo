using CleanDemo.Application.Reminders.Queries.GetReminder;

using TestCommon.TestConstants;

namespace TestCommon.Reminders;

public static class ReminderQueryFactory
{
    public static GetReminderQuery CreateGetReminderQuery(
        Guid? userId = null,
        Guid? subscriptionId = null,
        Guid? reminderId = null)
    {
        return new GetReminderQuery(
            userId ?? Constants.User.Id,
            subscriptionId ?? Constants.Subscription.Id,
            reminderId ?? Constants.Reminder.Id);
    }
}