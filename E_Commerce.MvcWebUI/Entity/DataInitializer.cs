using System.Data.Entity;

namespace E_Commerce.MvcWebUI.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            List<Category> categories = new List<Category>() {
            new Category() { Name="Bilgisayar", Description="Bilgisayar Ürünleri" },
            new Category() { Name="Telefon", Description="Telefon Ürünleri" },
            new Category() { Name="Beyaz Esya", Description="Beyaz Esya Ürünleri" },
            new Category() { Name="Tablet", Description="Tablet Ürünleri" },
            new Category() { Name="Elektronik", Description="Elektronik Ürünleri" },
                 };

            foreach (var item in categories)
            {
                context.Categories.Add(item);
            }
            context.SaveChanges();


            List<Product> products = new List<Product>() { 
                new Product() { Name="Iphone 13" , Description="Iphone 13 Pro Max 256 GB", Price=28900,Stock=14,IsApproved=true,CategoryId=2, IsHome=true,Image="1.jpg"},     
                new Product() { Name="Iphone 14" , Description="Iphone 14 Pro Max 256 GB", Price=38900,Stock=14,IsApproved=true,CategoryId=2,IsHome=true,Image="2.jpg"},    
                new Product() { Name="Thinkpad x280" , Description="Thinkpad x280 512GB SSD 16 GB Ram ", Price=28900,Stock=14,IsApproved=true,CategoryId=1,Image="3.jpg"},     
                new Product() { Name="Thinkpad X1 Carbon" , Description="Thinkpad X1 512GB SSD 16 GB Ram i7 8850 islemci ", Price=28900,Stock=14,IsApproved=true,CategoryId=1,IsHome=true,Image="4.jpg"},     
                new Product() { Name="Buzdolabı" , Description="Arcelik No Frost buzdolabı", Price=28900,Stock=14,IsApproved=true,CategoryId=3,Image="5.jpg"},   
                new Product() { Name="İpad Nano" , Description="İpad Nano Tablet 128 GB 3 Gen", Price=32000,Stock=14,IsApproved=true,CategoryId=4,Image="6.jpg"},
                new Product() { Name="İpad Nano Gen 5" , Description="İpad Nano Tablet 256 GB 5 Gen", Price=32000,Stock=14,IsApproved=true,CategoryId=4,Image="6.jpg"} };

            foreach (var item in products)
            {
                context.Products.Add(item);

            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
