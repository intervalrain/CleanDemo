using CleanDemo.Application.Common.Interfaces;
using CleanDemo.Domain.Reminders;

namespace CleanDemo.Infrastructure.Reminders.Persistence;

public class RemindersRepository : IRemindersRepository
{
    private readonly Dictionary<Guid, Reminder> _reminders = new();

    public async Task AddAsync(Reminder reminder, CancellationToken cancellationToken)
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

    public async Task<Reminder?> GetByIdAsync(Guid reminderId, CancellationToken cancellationToken)
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

    public Task<List<Reminder>> ListBySubscriptionIdAsync(Guid subscriptionId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveAsync(Reminder reminder, CancellationToken cancellationToken)
    {
        await Task.Run(() =>
        {
            if (!_reminders.ContainsKey(reminder.Id))
            {
                return;
            }
            _reminders.Remove(reminder.Id);
        });
    }

    public async Task RemoveRangeAsync(List<Reminder> reminders, CancellationToken cancellationToken)
    {
        foreach (var reminder in reminders)
        {
            await RemoveAsync(reminder, cancellationToken);
        }
        
    }

    public async Task UpdateAsync(Reminder reminder, CancellationToken cancellationToken)
    {
        await Task.Run(() =>
        {
            _reminders[reminder.Id] = reminder;
        });
    }
}

