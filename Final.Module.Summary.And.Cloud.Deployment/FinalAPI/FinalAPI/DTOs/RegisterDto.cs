using DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace FinalAPI.DTOs;

public class RegisterDto
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    [MinLength(2), MaxLength(20)]
    public required string Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [MinLength(2), MaxLength(20)]
    public required string Password { get; set; }
}

public static class RegisterDtoExtensions
{
    public static AppUser ToUser(this RegisterDto dto)
    {
        return new AppUser()
        {
            Email = dto.Email,
            UserName = dto.Username
        };
    }
}


//1) models
//2) seed
//3) database update
//4) dtos (ToEntity extension) //user.ToDto
//5) controller
//6) swagger/postman tests
//add models (step 1)
