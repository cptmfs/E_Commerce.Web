﻿using E_Commerce.MvcWebUI2.Entity;
using E_Commerce.MvcWebUI2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.MvcWebUI2.Controllers
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
        public ActionResult List(int? id)
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
                }).AsQueryable();

            if (id!=null)
            {
                products = products.Where(i => i.CategoryId == id);
            }

            return View(products.ToList());
        }
        public PartialViewResult GetCategories()
        {
            return PartialView(_context.Categories.ToList());
        }
    }
}