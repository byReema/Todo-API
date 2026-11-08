using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models;

// this is the request DTO
//describes the category data the API accepts
public record CategoryRequest(
    [Required]
    [StringLength(80, MinimumLength = 1)]
    string Name
);