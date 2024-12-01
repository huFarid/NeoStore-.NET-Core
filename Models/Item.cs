using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NeoStore.Models
{
    public class Item
    {
        [Key]
        public int ID { get; set; }

        [Precision(18, 2)] // Adjust as needed
        public decimal Price { get; set; }  
        public int QuantityInStock {  get; set; }

        public Product Product { get; set; }
      

    }
}
