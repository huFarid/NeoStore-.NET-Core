using System.ComponentModel.DataAnnotations;

namespace NeoStore.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public  DateTime OrderDate { get; set; }
        public bool IsFinalized { get; set; }
        public User User { get; set; }
        public List<OrderDetail> Details { get; set; }
    }
}
