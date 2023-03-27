using Microsoft.EntityFrameworkCore;
using TodoCQRS.Domain.Entities;
using TodoCQRS.Infrastructure.Data.Context;

namespace TodoCQRS.Infrastructure.Data.Repositories;

public interface ITodoRepository
{
    Task AddAsync(Todo todo);
    Task<List<Todo>> GetAllAsync();
    Task<Todo?> GetByIdAsync(Guid id);
    Task UpdateAsync(Todo todo);
    Task DeleteAsync(Guid id);
    Task<List<Todo>> GetPendingTodosAsync();
    Task<List<Todo>> GetCompletedTodosAsync();
}

public class TodoRepository : ITodoRepository
{
    private readonly ApplicationDbContext _context;

    public TodoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Todo todo)
    {
        await _context.Todos.AddAsync(todo);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Todo>> GetAllAsync()
    {
        var result = await _context.Todos.ToListAsync();
        return result;
    }

    public async Task<Todo?> GetByIdAsync(Guid id)
    {
        return await _context.Todos.FindAsync(id);
    }

    public async Task UpdateAsync(Todo todo)
    {
        _context.Entry(todo).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var todo = await _context.Todos.FindAsync(id);
        if (todo != null)
        {
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Todo>> GetPendingTodosAsync()
    {
        return await _context.Todos.Where(x => !x.IsCompleted).ToListAsync();
    }

    public async Task<List<Todo>> GetCompletedTodosAsync()
    {
        return await _context.Todos.Where(x => x.IsCompleted).ToListAsync();
    }
}