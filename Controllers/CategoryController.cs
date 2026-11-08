using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers;

[ApiController]
[Route("categories")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        this.categoryService = categoryService;
    }

    [HttpGet]
    public async  Task<IActionResult> GetAll()
    {
        var category = await categoryService.GetAllAsync(); 
        return Ok(category);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        //this will through an exception if it is finds duplicated Ids
        var category = await categoryService.GetByIdAsync(id);

        if (category is null)
        {
            return NotFound();
        }

        return Ok(category);
    }

[HttpPost]
    public async Task<IActionResult> CreateCategory(CategoryRequest request)
    {
        var createdCategory = await categoryService.CreateAsync(request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = createdCategory.Id },
            createdCategory
        );
    }


}