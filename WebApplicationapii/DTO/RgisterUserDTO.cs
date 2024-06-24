using System.ComponentModel.DataAnnotations;

namespace WebApplicationapii.DTO
{
    public class RgisterUserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }


    }
}
