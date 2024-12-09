using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoStore.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UserId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(300)]
        public string Password { get; set; } 

        public DateTime RegistrationTime { get; set; }

        public bool IsAdmin {  get; set; }
    }
}
