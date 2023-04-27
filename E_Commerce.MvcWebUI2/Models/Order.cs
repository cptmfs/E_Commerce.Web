using E_Commerce.MvcWebUI2.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.MvcWebUI2.Models
{
	public class Order
	{
		public int Id { get; set; }
		public string OrderNumber { get; set; }
		public double Total { get; set; }
		public DateTime OrderDate { get; set; }
		public EnumOrderState OrderState { get; set; }
		public string UserName { get; set; }
		public string AdressTitle { get; set; }
		public string Adress1 { get; set; }
		public string City { get; set; }
		public string Region { get; set; }
		public string Country { get; set; }
		public string PostalCode { get; set; }
		public virtual List<OrderLine> OrderLines { get; set; }

	}
	public class OrderLine
	{
		public int Id { get; set; }
		public int OrderId { get; set; }
		public virtual Order Order { get; set; }
		public int Quantity { get; set; }
		public double Price { get; set; }
		public int ProductId { get; set; }
		public virtual Product	Product { get; set; }
	}
}