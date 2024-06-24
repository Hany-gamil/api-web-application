using System.ComponentModel.DataAnnotations;

namespace WebApplicationapii.DTO
{
    public class loginUserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
