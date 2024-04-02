using CleanDemo.Application.Common.Interfaces;
using CleanDemo.Application.Common.Models;

namespace TestCommon.Security;

public class TestCurrentUserProvider : ICurrentUserProvider
{
    private CurrentUser? _currentUser;

    public CurrentUser GetCurrentUser() => _currentUser ?? CurrentUserFactory.CreateCurrentUser();

    public void Returns(CurrentUser currentUser)
    {
        _currentUser = currentUser;
    }
    
}

