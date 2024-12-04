using System.ComponentModel.DataAnnotations;

namespace NeoStore.Models
{
    public class User
    {
        [Key]
        public string UserId { get; set; }

        [Required]
        
        public string Email { get; set; }


        [Required]
        [MaxLength(300)]
        public string Password { get; set; } 
        

        [Required]
        [MaxLength(300)]
        public string ConfirmPassword { get; set; }

        public DateTime RegistrationTime { get; set; }

        public bool IsAdmin {  get; set; }


        
    }
}
