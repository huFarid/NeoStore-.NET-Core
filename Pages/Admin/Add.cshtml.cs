using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.Identity.Client;
using NeoStore.Data;
using NeoStore.Models;
using NUnit.Framework.Internal.Execution;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace NeoStore.Pages.Admin
{
    public class AddModel : PageModel
    {

        private readonly EshopContext _context;
        public AddModel(EshopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AddEditProductViewModel Product { get; set; }
        
        public void OnGet()
        {


        }

       public IActionResult OnPost() { 
        
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var newProduct = new Product()
            {
                Name = Product.Name,
                Description = Product.Description,
                Item = new Models.Item()
                {
                    Price = Product.Price,
                    QuantityInStock = Product.QuantityInStock
                    
                }
                
            };
            
              
            

            _context.Add(newProduct);
            _context.SaveChanges();
            newProduct.ItemId = newProduct.Id;
            _context.SaveChanges();


            if (Product.Picture?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "images",
                    newProduct.Id.ToString()+".jpg");

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                   Product.Picture.CopyTo(fileStream);
                }


            }

            return RedirectToPage("Index"); 
        }

        

      
    }
}
