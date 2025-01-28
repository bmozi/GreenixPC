    
using Microsoft.EntityFrameworkCore; 
  


// Todo Service CRUD Interface
public interface ITodoService
{
    // Create
    Task<TodoItem> CreateAsync(TodoItem item);
    // Read
    Task<IEnumerable<TodoItem>> GetAllAsync();
    Task<TodoItem?> GetByIdAsync(int id);
    // Update
    Task<bool> UpdateAsync(int id, TodoItem item);
    // Delete
    Task<bool> DeleteAsync(int id);
}


// Service CRUD Implementation
public class TodoService : ITodoService
{
    private readonly TodoContext _context;

    public TodoService(TodoContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TodoItem>> GetAllAsync()
    {
        return await _context.TodoItems.ToListAsync();
    }

    public async Task<TodoItem?> GetByIdAsync(int id)
    {
        return await _context.TodoItems.FindAsync(id);
    }

    public async Task<TodoItem> CreateAsync(TodoItem item)
    {
        _context.TodoItems.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<bool> UpdateAsync(int id, TodoItem item)
    {
        var existingItem = await _context.TodoItems.FindAsync(id);
        if (existingItem == null) return false;

        existingItem.Title = item.Title;
        existingItem.IsCompleted = item.IsCompleted;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await _context.TodoItems.FindAsync(id);
        if (item == null) return false;

        _context.TodoItems.Remove(item);
        await _context.SaveChangesAsync();
        return true;
    }
}
