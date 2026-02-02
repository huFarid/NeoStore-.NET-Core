using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NeoStore.Data;
using NeoStore.Models;

namespace NeoStore.Pages.Admin
{
    public class EditModel : PageModel
    {
        public AddEditProductViewModel Product { get; set; }
        EshopContext _context;
        public EditModel(EshopContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
    }
}
