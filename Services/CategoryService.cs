using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Services;

public class CategoryService : ICategoryService
{
    private readonly TodoDbContext dbContext;

    public CategoryService(TodoDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        // get the categories from MySQL
        return await dbContext.Categories.ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await dbContext.Categories.FindAsync(id);
    }

    public async Task<Category> CreateAsync(CategoryRequest request)
    {
        var category = new Category
        {
            Name = request.Name
        };

        dbContext.Categories.Add(category);
        await dbContext.SaveChangesAsync(); // MySQL gives the category its Id here

        return category;
    }
}