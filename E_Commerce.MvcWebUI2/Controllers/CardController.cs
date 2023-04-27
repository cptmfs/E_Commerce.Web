using E_Commerce.MvcWebUI2.Entity;
using E_Commerce.MvcWebUI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.MvcWebUI2.Controllers
{
    
    public class CardController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Card
        public ActionResult Index()
        {
            return View(GetCard());
        }
        public ActionResult AddToCard(int Id)
        {
            var product=db.Products.FirstOrDefault(i=> i.Id== Id);
            if (product!=null)
            {
                GetCard().AddProduct(product, 1);
            }
            return RedirectToAction("Index");
        }
		public ActionResult RemoveFromCard(int Id)
		{
			var product = db.Products.FirstOrDefault(i => i.Id == Id);
			if (product != null)
			{
				GetCard().DeleteProduct(product);
			}
			return RedirectToAction("Index");
		}
		public Card GetCard()
        {
            var card = (Card)Session["Card"];

            if (card==null) // eğer kullanıcının bir kartı yoksa ona bir kart tanımla
            {
                card=new Card();
                Session["Card"] = card; // o kartı session'a at . **Session ile farklı kullanıcılara ait farklı verileri tutabiliyoruz..
            }
            return card;
        } 
        public PartialViewResult Summary()
        {
            return PartialView(GetCard());
        }
        
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
		public ActionResult Checkout(ShippingDetails shipping)
		{
            var card = GetCard();
            if (card.CardLines.Count==0)
            {
                ModelState.AddModelError("BosSepetError","Sepetinizde ürün bulunmamaktadır.");
            }
			if (ModelState.IsValid)
			{
                // Siparişi veritabanına kayıt et.
                // Sepeti sıfırla.

                SaveOrder(card, shipping);

				card.Clear();
				return View("Completed");
			}
			else
			{
				return View(shipping);
			}
		}

		private void SaveOrder(Card card, ShippingDetails shipping)
		{
            var order = new Order();
            order.OrderNumber = "A"+(new Random()).Next(11111,99999).ToString(); // her sipariş için benzersiz numara.
            order.Total = card.Total();
            order.OrderDate = DateTime.Now;
            order.UserName = shipping.UserName;
            order.AdressTitle = shipping.AdressTitle;
            order.Adress1=shipping.Adress1;
            order.City = shipping.City;
            order.Region = shipping.Region;
            order.Country = shipping.Country;
            order.PostalCode = shipping.PostalCode;

            order.OrderLines = new List<OrderLine>();
            foreach (var item in card.CardLines)
            {
                OrderLine orderLine = new OrderLine();
                orderLine.Quantity=item.Quantity;
                orderLine.Price = item.Quantity*item.Product.Price;
                orderLine.ProductId = item.Product.Id;

                order.OrderLines.Add(orderLine);
            }
            db.Orders.Add(order);
            db.SaveChanges();

		}
	}
}
