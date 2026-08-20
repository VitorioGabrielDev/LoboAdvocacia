using System.Linq.Expressions;
using Lobo.Application.UserContext.Repositories;
using Lobo.Domain.UserContext.Entities;

namespace Lobo.Application.Tests.UserContext.Repositories;

public class FakeUserRepository : IUserRepository
{
    private readonly List<User> _users = [];
    
    public Task AddAsync(User user)
    {
        _users.Add(user);
        return Task.CompletedTask;
    }

    public Task<User?> GetBySpecAsync(Expression<Func<User, bool>> expression)
    {
        Func<User, bool> predicate = expression.Compile();
        return Task.FromResult(_users.FirstOrDefault(predicate));
    }

    public Task Update(User user)
    {
        
        if (_users.FirstOrDefault(u => u.Id == user.Id) is User existingUser)
        {
            _users.Remove(existingUser);
            _users.Add(user);
        }
        
        return Task.CompletedTask;
    }

    public Task Delete(User user)
    {
        _users.Remove(user);
        return Task.CompletedTask;
    }
}