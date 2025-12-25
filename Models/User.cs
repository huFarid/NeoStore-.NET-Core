using Microsoft.Exchange.WebServices.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoStore.Models
{
    public class User
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UserId { get; set; }
        //public Guid UserId { get; set; } = Guid.NewGuid();  // auto-generate on creation

        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(300)]
        public string Password { get; set; }

        public DateTime RegistrationTime { get; set; } 

        public bool IsAdmin {  get; set; }

        public List<Order> Orders { get; set; }
    }
}
