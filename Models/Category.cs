using System.ComponentModel.DataAnnotations;

namespace NeoStore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }

    }
}
