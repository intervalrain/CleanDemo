using CleanDemo.Application.Common.Interfaces;
using CleanDemo.Domain.Users;

namespace CleanDemo.Infrastructure.Users.Persistence;

public class UsersRepository : IUsersRepository
{
    private readonly Dictionary<Guid, User> _users = new();

    public async Task AddUserAsync(User user)
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

    public async Task<User?> GetByIdAsync(Guid userId)
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

    public async Task UpdateUserAsync(User user)
    {
        await Task.Run(() =>
        {
            _users[user.Id] = user;
        });
    }
}