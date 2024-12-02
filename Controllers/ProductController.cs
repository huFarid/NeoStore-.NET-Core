using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeoStore.Data;
using NeoStore.Models;
using System.ComponentModel.DataAnnotations;

namespace NeoStore.Controllers
{
    public class ProductController:Controller
    {
        private EshopContext _context;
        public ProductController(EshopContext context)
        {
            _context = context;
            
        }

        
        [Route("/Group/{Id}/{name}")]
        public IActionResult ShowGroupProducts(int Id, string name)
        {
            ViewData["GroupName"] = name;
            var groupProducts = _context.CategoryToProducts
                .Where(ca=> ca.CategoryID ==Id)
                .Include(c => c.Product)
                .Select(c => c.Product)
                .ToList();

            return View(groupProducts);

        }

    }
}
