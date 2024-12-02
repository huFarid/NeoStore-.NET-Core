using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeoStore.Data;
using NeoStore.Models;

namespace NeoStore.Controllers
{
    public class ProductController:Controller
    {
        private EshopContext _context;
        public ProductController(EshopContext context)
        {
            _context = context;
            
        }

        
        [Route("/Group/{Id}")]
        public IActionResult ShowGroupProducts(int Id)
        {
            var groupProducts = _context.CategoryToProducts
                .Where(ca=> ca.CategoryID ==Id)
                .Include(c => c.Product)
                .Select(c => c.Product)
                .ToList();

            return View(groupProducts);

        }

    }
}
