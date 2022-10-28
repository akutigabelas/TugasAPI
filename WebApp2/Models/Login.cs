using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace WebApp2.Models
{
    public class Login
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Email is requried!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is requried!")]
        public string Password { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set;}
    }
}
