using E_Commerce.MvcWebUI.Entity;
using E_Commerce.MvcWebUI.Models;
using E_Commerce.MvcWebUI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E_Commerce.MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        DataContext _context = new DataContext();
            public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            var products=_context.Products.Where(x=> x.IsHome && x.IsApproved).
                Select(y=>new ProductViewModel()
                {
                    Id=y.Id,
                    Name = y.Name.Length > 50 ? y.Name.Substring(0, 47) + "..." : y.Name,
                    Description = y.Description.Length>50 ? y.Description.Substring(0,47)+"...":y.Description,
                    Price= y.Price,
                    Stock=y.Stock,
                    Image=y.Image ?? "1.jpg",
                    CategoryId=y.CategoryId
                }).ToList();

            return View(products);
        }
        public IActionResult Details(int id)
        {
            return View(_context.Products.Where(x => x.Id==id).FirstOrDefault());
        }
        public IActionResult List()
        {
            var products = _context.Products.Where(x => x.IsApproved).
                Select(y => new ProductViewModel()
                {
                    Id = y.Id,
                    Name = y.Name.Length > 50 ? y.Name.Substring(0, 47) + "..." : y.Name,
                    Description = y.Description.Length > 50 ? y.Description.Substring(0, 47) + "..." : y.Description,
                    Price = y.Price,
                    Stock = y.Stock,
                    Image = y.Image ?? "1.jpg",
                    CategoryId = y.CategoryId
                }).ToList();

            return View(products);
        }
        public PartialViewResult GetCategories()
        {
            return PartialView(_context.Categories.ToList());
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