using System.ComponentModel.DataAnnotations;

namespace Netrom.Components.Models;

public class UserModel
{
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public required string LastName { get; set; }
    
    public required DateTime Birthday { get; set;  }
    
    public required string Gender { get; set; }
}