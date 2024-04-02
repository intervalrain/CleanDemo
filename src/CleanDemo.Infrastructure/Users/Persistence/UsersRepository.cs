using CleanDemo.Application.Common.Interfaces;
using CleanDemo.Domain.Users;

namespace CleanDemo.Infrastructure.Users.Persistence;

public class UsersRepository : IUsersRepository
{
    private readonly Dictionary<Guid, User> _users = new();

    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        await Task.Run(() =>
        {
            if (_users.ContainsKey(user.Id))
            {
                throw new InvalidOperationException();
            }
            _users.Add(user.Id, user);
        });
    }

    public async Task<User?> GetByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await Task.Run(() =>
        {
            if (!_users.ContainsKey(userId))
            {
                throw new KeyNotFoundException();
            }
            return _users[userId];
        });
    }

    public Task<User?> GetBySubscriptionIdAsync(Guid subscriptionId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveAsync(User user, CancellationToken cancellationToken)
    {
        await Task.Run(() =>
        {
            if (!_users.ContainsKey(user.Id))
            {
                return;
            }
            _users.Remove(user.Id);
        });
    }

    public async Task UpdateAsync(User user, CancellationToken cancellationToken)
    {
        await Task.Run(() =>
        {
            _users[user.Id] = user;
        });
    }
}