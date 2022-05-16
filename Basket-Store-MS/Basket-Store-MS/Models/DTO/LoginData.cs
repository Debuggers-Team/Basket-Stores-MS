using System.ComponentModel.DataAnnotations;

namespace Basket_Store_MS.Models.DTO
{
    public class LoginData
    {
        [Required(ErrorMessage = "The Username is required!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The password is required!")]
        public string Password { get; set; }
    }
}
