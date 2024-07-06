using System.ComponentModel.DataAnnotations;
using Netrom.Entities;

namespace Netrom.Components.Models;

public class UserDto
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; }
   
    [Required(ErrorMessage = "Birthday is required")]
    public DateTime Birthday { get; set;  }
    
    [Required(ErrorMessage = "Gender is required")]
    [StringLength(1, MinimumLength = 1)]
    public string Gender { get; set; }

    public bool Exists { get; set; } = true;
}