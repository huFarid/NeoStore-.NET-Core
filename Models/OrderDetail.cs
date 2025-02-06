using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoStore.Models
{
    public class OrderDetail
    {
        [Key]
        public  int DetailId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductID { get; set; }

        public Order Order { get; set; }
        public int Count { get; set; }

        [ForeignKey("ProductID")]
        public Product Product { get; set; }
        [Required]
        public decimal  OrderPrice { get; set; }
    }
}
