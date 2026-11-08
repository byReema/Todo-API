using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Services;

public class TodoService : ITodoService
{
    private readonly TodoDbContext dbContext;

    // inject
    public TodoService(TodoDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<List<Todo>> GetAllAsync()
    {
        // ask EF Core to load all todos from the database
        return await dbContext.Todos.ToListAsync();
    }

    public async Task<Todo?> GetByIdAsync(int id)
    {
        //look up a todo by its primary key; returns null if it's not found
        return await dbContext.Todos.FindAsync(id);
    }

    public async Task<Todo> CreateAsync(TodoRequest request)
    {
        var todo = new Todo
        {
            // we leave Id alone; MySQL will give it one when we save
            Name = request.Name,
            DueDate = request.DueDate,
            IsCompleted = request.IsCompleted
        };

        //mark the new todo for insertion; SaveChangesAsync sends it to the database
        dbContext.Todos.Add(todo);
        await dbContext.SaveChangesAsync();

        return todo;
    }

    public async Task<Todo?> UpdateAsync(int id, TodoRequest request)
    {
        var todo = await dbContext.Todos.FindAsync(id);

        if (todo is null)
        {
            return null;
        }

        todo.Name = request.Name;
        todo.DueDate = request.DueDate;
        todo.IsCompleted = request.IsCompleted;

        await dbContext.SaveChangesAsync();
        return todo;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var todo = await dbContext.Todos.FindAsync(id);

        if (todo is null)
        {
            return false;
        }

        dbContext.Todos.Remove(todo);
        await dbContext.SaveChangesAsync();

        return true;
    }
}