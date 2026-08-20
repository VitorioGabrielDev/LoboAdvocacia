using System.Linq.Expressions;
using Lobo.Domain.UserContext.Entities;

namespace Lobo.Application.UserContext.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User?> GetBySpecAsync(Expression<Func<User, bool>> expression);
    Task Update(User user);
    Task Delete(User user);
}