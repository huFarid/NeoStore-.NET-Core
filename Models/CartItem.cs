using System.ComponentModel.DataAnnotations;

namespace NeoStore.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }

        public decimal getTotalPrice()
        {
            decimal totalPric = ItemQuantity * Item.Price;
            return totalPric;
            
        }

    }
}
