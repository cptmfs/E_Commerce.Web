using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.MvcWebUI2.Models
{
	public class ShippingDetails
	{
		public string UserName { get; set; }
		[Required(ErrorMessage ="Lütfen Adress Tanımını Giriniz.")]
		public string AdressTitle { get; set; }
		[Required(ErrorMessage = "Lütfen Adress Giriniz.")]
		public string Adress1 { get; set; }
		//public string Adress2 { get; set;}
		[Required(ErrorMessage = "Lütfen Şehir Bilgisi Giriniz.")]
		public string City { get; set; }
		[Required(ErrorMessage = "Lütfen İlçe Bilgisi Giriniz.")]
		public string Region { get; set; }
		[Required(ErrorMessage = "Lütfen Ülke Bilgisi Giriniz.")]
		public string Country { get; set; }
		[Required(ErrorMessage = "Lütfen Posta Kodu Giriniz.")]
		public string PostalCode { get; set; }
	}
}