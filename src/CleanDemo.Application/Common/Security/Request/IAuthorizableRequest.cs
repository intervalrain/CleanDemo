using MediatR;

namespace CleanDemo.Application.Common.Security.Request;

public interface IAuthorizableRequest<T> : IRequest<T>
{
    Guid UserId { get; } 
}