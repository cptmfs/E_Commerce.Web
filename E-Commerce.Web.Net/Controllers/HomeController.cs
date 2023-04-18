using E_Commerce.MvcWebUI.Entity;
using E-Commerce.WebNet.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Web.Net.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DataContext _context = new DataContext();

        public ActionResult Index()
        {

            var products = _context.Products.Where(x => x.IsHome && x.IsApproved).
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
        public ActionResult Details(int id)
        {
            return View(_context.Products.Where(x => x.Id == id).FirstOrDefault());
        }
        public ActionResult List()
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
    }
}