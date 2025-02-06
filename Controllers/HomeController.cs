using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeoStore.Data;
using NeoStore.Migrations;
using NeoStore.Models;
using System.Diagnostics;
using System.Security.Claims;

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

        public IActionResult RemoveCart(int Id)
        {

            _cart.RemoveItem(Id);

            return RedirectToAction("ShowCart");
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






        //[Authorize]
        //public IActionResult AddToCart(int ItemID)
        //{
        //    var product = _context.Products.Include(p => p.Item).SingleOrDefault(p => p.ItemId == ItemID);


        //    if (product != null)
        //    {
        //        //string  userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //        //var userIdTest = int.TryParse(userID, out var id) ? id : 0;


        //         string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //        //int id = int.Parse(User.FindFirstValue(claimType.NameIdentifie))
        //        var order = _context.Orders.FirstOrDefault(o=> o.UserId == userId  && !o.IsFinalized); 

        //        if (order != null)
        //        {
        //            var orderDetail = _context.OrderDetails.FirstOrDefault(detail=> detail.OrderId == order.OrderId  && detail.ProductID == product.Id);
        //            if (orderDetail != null)
        //            {
        //                orderDetail.Count += 1;

        //            }
        //            else
        //            {
        //                _context.OrderDetails.Add(new OrderDetail()
        //                {
        //                    Count = 1,
        //                    OrderId = order.OrderId,
        //                    ProductID = product.Id,
        //                    OrderPrice = product.Item.Price,
        //                });

        //            }


        //        }
        //        else
        //        {
        //            order = new Order()
        //            {
        //                IsFinalized = false,
        //                OrderDate = DateTime.Now,
        //                UserId = userId
        //            };
        //            _context.Orders.Add(order);
        //            _context.SaveChanges();
        //            var orderDetails = new OrderDetail()
        //            {
        //                OrderId = order.OrderId,
        //                ProductID = product.Id,
        //                OrderPrice = product.Item.Price,
        //                Count = 1


        //            };
        //            _context.SaveChanges();

                    

        //        }
        //    }
        //    return RedirectToAction("ShowCart");
        //}

        public IActionResult ShowCart()
        {
            CartViewModel cartViewModel = new CartViewModel()
            {
                CartItems = _cart.CartItems,
                OrderTotalPrice = _cart.CartItems.Sum(i => i.getTotalPrice())


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

