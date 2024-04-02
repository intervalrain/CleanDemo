using CleanDemo.Application.Common.Models;

namespace CleanDemo.Application.Common.Interfaces;

public interface ICurrentUserProvider
{
    CurrentUser GetCurrentUser();
}

