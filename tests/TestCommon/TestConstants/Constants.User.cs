using CleanDemo.Application.Common.Security.Permissions;
using CleanDemo.Application.Common.Security.Roles;

namespace TestCommon.TestConstants;

public static partial class Constants
{
    public static class User
    {
        public const string FirstName = "Rain";
        public const string LastName = "Hu";
        public const string Email = "intervalrain@gmail.com";
        public static readonly Guid Id = Guid.NewGuid();
        public static readonly List<string> Permissions = new List<string>
        {
            Permission.Reminder.Get,
            Permission.Reminder.Set,
            Permission.Reminder.Delete,
            Permission.Reminder.Dismiss,
            Permission.Subscription.Create,
            Permission.Subscription.Delete,
            Permission.Subscription.Get
        };

        public static readonly List<string> Roles = new List<string>
        {
            Role.Admin
        };
    }
}

