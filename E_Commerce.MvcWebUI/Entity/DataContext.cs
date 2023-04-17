﻿using System.Data.Entity;

namespace E_Commerce.MvcWebUI.Entity
{
    public class DataContext:DbContext
    {
        public DataContext() : base("dataConnection") => Database.SetInitializer(new DataInitializer());
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
