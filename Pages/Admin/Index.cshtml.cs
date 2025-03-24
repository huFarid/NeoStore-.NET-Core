using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NeoStore.Data;
using NeoStore.Models;

namespace NeoStore.Pages.Admin
{
    public class IndexModel : PageModel
    {



        private EshopContext _context;

        public IndexModel(EshopContext context)
        {
            _context = context;

        }


        public IEnumerable<Product> Products { get; set; }
        public void OnGet()
        {
            Products = _context.Products;
        }
        public void OnPost()
        {
            
        }

    }
}
