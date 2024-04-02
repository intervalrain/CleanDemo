using CleanDemo.Domain.Reminders;

namespace CleanDemo.Application.Common.Interfaces;

public interface IRemindersRepository
{
    Task AddReminderAsync(Reminder reminder);
    Task<Reminder?> GetReminderByIdAsync(Guid reminderId);
}

