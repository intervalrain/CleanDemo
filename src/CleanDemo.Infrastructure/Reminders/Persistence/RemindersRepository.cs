using CleanDemo.Application.Common.Interfaces;
using CleanDemo.Domain.Reminders;

namespace CleanDemo.Infrastructure.Reminders.Persistence;

public class RemindersRepository : IRemindersRepository
{
    private readonly Dictionary<Guid, Reminder> _reminders = new(); 

    public async Task AddReminderAsync(Reminder reminder)
    {
        await Task.Run(() =>
        {
            if (_reminders.ContainsKey(reminder.Id))
            {
                throw new InvalidOperationException();
            }
            _reminders.Add(reminder.Id, reminder);
        });
    }

    public async Task<Reminder?> GetReminderByIdAsync(Guid reminderId)
    {
        return await Task.Run(() =>
        {
            if (!_reminders.ContainsKey(reminderId))
            {
                throw new KeyNotFoundException();
            }
            return _reminders[reminderId];
        });
    }
}

