using Lobo.Domain.SharedContext.Entities;

namespace Lobo.Application.SharedContext.Repositories;

public interface ITodoRepository
{
    public Task<List<Todo>> GetTodo()
}