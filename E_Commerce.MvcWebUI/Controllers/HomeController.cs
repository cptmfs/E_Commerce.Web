using E_Commerce.MvcWebUI.Entity;
using E_Commerce.MvcWebUI.Models;
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

            return View(_context.Products.Where(x=> x.IsHome && x.IsApproved).ToList());
        }
        public IActionResult Details(int id)
        {
            return View(_context.Products.Where(x => x.Id==id).FirstOrDefault());
        }
        public IActionResult List()
        {
            return View(_context.Products.ToList());
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