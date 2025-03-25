using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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
            Products = _context.Products.Include(p=>p.Item);
        }
        public void OnPost()
        {
            
        }

    }
}
