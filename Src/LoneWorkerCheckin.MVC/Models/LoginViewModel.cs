using System.ComponentModel.DataAnnotations;

namespace LoneWorkerCheckin.MVC.Models;

public class LoginViewModel
{
    public string UserId { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is requried!")]
    public string Email { get; set; }
}
