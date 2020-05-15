using System.ComponentModel.DataAnnotations;

namespace TodoCycle.DTO
{
    public class UserForLoginDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}