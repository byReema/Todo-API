namespace TodoApi.Models;

public class Category
{
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;

    // one category can have lots of todos
    public ICollection<Todo> Todos { get; set; } = new List<Todo>();
}