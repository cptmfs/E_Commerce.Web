using E_Commerce.MvcWebUI2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.MvcWebUI2.Models
{
    public class Card
    {
        private List<CardLine> _cardLines= new List<CardLine>(); 
        public List<CardLine> CardLines // kullanıcıya gösterilecek kartı tanımladık
        {
            get { return _cardLines; }
        }
        public void AddProduct(Product product,int quantity)
        {
            var line=_cardLines.FirstOrDefault(i=> i.Product.Id==product.Id); //kartların içerisinde ürün ıd sini bul ve kontrol et
            if (line==null) // eğer sepet boş ise  yada o ürün yok ise
            {
                _cardLines.Add(new CardLine() { Product = product, Quantity = quantity }); //sepete ürünü ekle
            }
            else
            {
                line.Quantity += quantity; // adet ekle
            }
        }
        public void DeleteProduct(Product product)
        {
            _cardLines.RemoveAll(i=> i.Product.Id==product.Id); // sepet içerisinde gelen id değerindeki ürünü sil 
        }
        public double Total()
        {
            return _cardLines.Sum(i => i.Product.Price * i.Quantity); // ürün fiyatı ile adeti çarpıp toplam fiyatı bul
        }
        public void Clear()
        {
            _cardLines.Clear(); // kart içeriğini temizle
        }

    }
    public class CardLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}