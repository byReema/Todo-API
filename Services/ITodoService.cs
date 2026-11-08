using TodoApi.Models;
namespace TodoApi.Services;

public interface ITodoService
{
    //the Async suffix and Task<...> mean the method will do its work asynchronously, which is useful for database operations
    Task<List<Todo>> GetAllAsync();
    // the ? on Todo? means the result may be missing, such as when an ID isn’t found
    Task<Todo?> GetByIdAsync(int id);
    //we chage it from Todo into TodoRequest to indicate that user not changeing or updateing the ID
    Task<Todo> CreateAsync(TodoRequest request);
    Task<Todo?> UpdateAsync(int id, TodoRequest request);
    Task<bool> DeleteAsync(int id);
}