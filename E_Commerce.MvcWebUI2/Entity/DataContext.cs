using E_Commerce.MvcWebUI2.Identity;
using E_Commerce.MvcWebUI2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E_Commerce.MvcWebUI2.Entity
{
    public class DataContext:DbContext
    {
        public DataContext() : base("dataConnection")
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
    }
}