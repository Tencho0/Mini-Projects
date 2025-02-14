namespace Mango.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class LoginRequestDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
