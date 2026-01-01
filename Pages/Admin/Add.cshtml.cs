using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NeoStore.Models;

namespace NeoStore.Pages.Admin
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public AddEditProductViewModel Product { get; set; }
        public void OnGet()
        {


        }
    }
}
