using CleanDemo.Domain.Users;

namespace CleanDemo.Application.Common.Interfaces;

public interface IUsersRepository
{
    Task AddUserAsync(User user);
    Task<User?> GetByIdAsync(Guid userId);
    Task UpdateUserAsync(User user);
}

