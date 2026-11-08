namespace TodoApi.Models;
public class Todo{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    
}