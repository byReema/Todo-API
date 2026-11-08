using System.ComponentModel.DataAnnotations;
namespace TodoApi.Models;

// we create this model so user send only these info and we will handel that he cant duplicate
// the id or choosing it 
public record TodoRequest(
    //these validation for this field
    [Required]
    [StringLength(100, MinimumLength = 1)]
    string Name,

    DateTime DueDate,
    bool IsCompleted,
    int? CategoryId = null // can be left out 

);