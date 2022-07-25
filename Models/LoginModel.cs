using System.ComponentModel.DataAnnotations;

namespace MVC_OT.Models;

public class LoginModel
{

    [Required(ErrorMessage = "กรุณากรอก User")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "กรุณากรอก Password")]
    public string Password { get; set; }
}