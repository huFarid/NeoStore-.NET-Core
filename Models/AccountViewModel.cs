using System.ComponentModel.DataAnnotations;

namespace NeoStore.Models
{
    public class AccountViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MaxLength(300)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MaxLength(300)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
