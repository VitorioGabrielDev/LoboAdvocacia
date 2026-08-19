using Lobo.Application.ProcessContext.Repositories;
using Lobo.Domain.ProcessContext;
using Lobo.Infrastructure.SharedContext.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Lobo.Infrastructure.ProcessContext.Repositories;

public class TodoRepository(
    AppDbContext dbContext
) : ITodoRepository
{
    public async Task<Todo?> GetTodoById(int id) =>
        await dbContext.Todos.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<Todo>> GetTodosByProcessIdAsync(int processId) =>
        await dbContext.Todos.Where(x => x.ProcessId == processId).ToListAsync();

    public async Task CreateTodoAsync(Todo todo) =>
        await dbContext.Todos.AddAsync(todo);

    public async Task<Todo?> UpdateTodoAsync(Todo todo)
    {
        Todo? trackedEntity = await GetTodoById(todo.Id);
        if (trackedEntity is null) return trackedEntity;
        
        dbContext.Entry(trackedEntity).CurrentValues.SetValues(todo);
        return trackedEntity;
    }

    public async Task<bool> DeleteTodoAsync(int id)
    {
        Todo? trackedEntity = await GetTodoById(id);
        if (trackedEntity is null) return false;
        
        dbContext.Todos.Remove(trackedEntity);
        return true;
    }
}