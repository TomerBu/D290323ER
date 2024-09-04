using System.ComponentModel.DataAnnotations;

namespace Lec7.ViewModels;

public class ManageViewModel
{
    public string? Password { get; set; } = null;

    public string? NewPassword { get; set; } = null;
    
    public string? Language { get; set; } = null;
}
