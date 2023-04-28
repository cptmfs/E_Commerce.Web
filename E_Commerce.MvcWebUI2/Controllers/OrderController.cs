using E_Commerce.MvcWebUI2.Entity;
using E_Commerce.MvcWebUI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.MvcWebUI2.Controllers
{
    [Authorize(Roles ="admin")]
    public class OrderController : Controller
    {
        // GET: Order
        DataContext db=new DataContext();
        public ActionResult Index()
        {
            var orders = db.Orders.Select(i => new AdminOrderModel()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
                Count=i.OrderLines.Count,
            }).OrderByDescending(i=>i.OrderDate).ToList();
            return View(orders);
        }
        public ActionResult Details(int id)
        {


			var entity = db.Orders.Where(i => i.Id == id)
				.Select(i => new OrderDetailsModel()
				{
					OrderId = i.Id,
					UserName=i.UserName,
					OrderNumber = i.OrderNumber,
					Total = i.Total,
					OrderDate = i.OrderDate,
					OrderState = i.OrderState,
					AdressTitle = i.AdressTitle,
					Adress1 = i.Adress1,
					City = i.City,
					Country = i.Country,
					Region = i.Region,
					PostalCode = i.PostalCode,
					OrderLines = i.OrderLines.Select(j => new OrderLineModel()
					{
						ProductId = j.ProductId,
						ProductName = j.Product.Name.Length > 50 ? j.Product.Name.Substring(0, 47) + "..." : j.Product.Name,
						Image = j.Product.Image,
						Quantity = j.Quantity,
						Price = j.Price
					}).ToList()
				}).FirstOrDefault();


			return View(entity);
        }

		public ActionResult UpdateOrderState(int orderId,EnumOrderState orderState)
		{
			var order = db.Orders.FirstOrDefault(i => i.Id == orderId);

			if (order != null)
			{
				order.OrderState = orderState;
				db.SaveChanges();
				TempData["message"] = "Sipariş durumu başarılı bir şekilde değiştirildi.";
				return RedirectToAction("Details", new { id = orderId });
			}
			return RedirectToAction("Index");
		}

	}
}