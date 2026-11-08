using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;


namespace TodoApi.Controllers;

[ApiController]
[Route("todos")]
public class TodoController : ControllerBase
{

    private readonly ITodoService todoService;

    public TodoController(ITodoService todoService)
    {
        this.todoService = todoService;
    }


    [HttpGet]
    //IActionResult means this method will return an HTTP response 
    public async Task<IActionResult> GetAll()
    {
        var todos = await todoService.GetAllAsync();
        return Ok(todos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        //this will through an exception if it is finds duplicated Ids
        var todo = await todoService.GetByIdAsync(id);

        if (todo is null)
        {
            return NotFound();
        }

        return Ok(todo);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(TodoRequest request)
    {
        var createdTodo = await todoService.CreateAsync(request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = createdTodo.Id },
            createdTodo
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TodoRequest request)
    {
        var todo = await todoService.UpdateAsync(id, request);

        if (todo is null)
        {
            return NotFound();
        }

        return Ok(todo);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await todoService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
