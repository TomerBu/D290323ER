using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Lec7.Models;

public class AppUser: IdentityUser
{
    [Required, MinLength(2), MaxLength(20)]
    public required string Language { get; set; }
}
