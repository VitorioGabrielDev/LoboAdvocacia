using Lobo.Domain.ProcessContext;

namespace Lobo.Application.ProcessContext.Repositories;

public interface ITodoRepository
{
    public Task<Todo?> GetTodoById(int id);
    public Task<List<Todo>> GetTodosByProcessIdAsync(int processId);
    public Task CreateTodoAsync(Todo todo);
    public Task<Todo?> UpdateTodoAsync(Todo todo);
    public Task<bool> DeleteTodoAsync(int id);
}