using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace NeoStore.Models
{
    public class CategoryToProduct
    {
       
       public int CategoryID { get; set; }  
       public int ProductID { get; set; }   


        public Product Product { get; set; }
        public Category Category { get; set; }

    }
}
