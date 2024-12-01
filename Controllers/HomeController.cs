using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeoStore.Data;
using NeoStore.Models;
using System.Diagnostics;

namespace NeoStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private EshopContext _context;
        private static Cart _cart = new Cart();
        public HomeController(ILogger<HomeController> logger, EshopContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products;
            return View(products);
        }
        public IActionResult Detail(int Id)
        {
            var product = _context.Products.Include(p => p.Item).SingleOrDefault(p => p.Id == Id);
            var categories = _context.Products.Where(p => p.Id == Id)
                 .SelectMany(p => p.CategoryToProducts)
                 .Select(CaToP => CaToP.Category).
                 ToList();


            var detailViewModel = new DetailViewModel()
            {
                Product = product,
                Categories = categories

            };

            return View(detailViewModel);

        }

        public IActionResult AddToCart(int ItemID)
        {
            var product = _context.Products.Include(p => p.Item).SingleOrDefault(p => p.ItemId == ItemID);


            if (product != null)
            {
                var cartItem = new CartItem()
                {
                    Item = product.Item,
                    ItemQuantity = 1

                };
                _cart.AddItem(cartItem);


            }
            return RedirectToAction("ShowCart");
        }

        public IActionResult ShowCart()
        {
            CartViewModel cartViewModel = new CartViewModel()
            {
                CartItems = _cart.CartItems

            };


            return View(cartViewModel);
        }


        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}