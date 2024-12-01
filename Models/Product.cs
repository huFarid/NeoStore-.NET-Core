using System.ComponentModel.DataAnnotations;

namespace NeoStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Item Item { get; set; }
        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
    }
}