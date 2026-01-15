using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NeoStore.Data;
using NeoStore.Models;
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
                Item = new Item()
                {
                    Price = Product.Price,
                    QuantityInStock = Product.QuantityInStock
                    
                }
                
            };
            
              
            

            _context.Add(newProduct);
            _context.SaveChanges();
            newProduct.ItemId = newProduct.Id;
            _context.SaveChanges();


            return RedirectToPage("Index"); 
        }

        

      
    }
}
