using E_ticaret_Uygulaması.Entity;
using E_ticaret_Uygulaması.Identity;
using E_ticaret_Uygulaması.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_ticaret_Uygulaması.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart


        private DataContext db = new DataContext();


        public ActionResult Index()
        {
            return View(GetCart());
        }
      
        public ActionResult AddToCart(int Id)
        {

            var product = db.Products.Where(i => i.Id == Id).FirstOrDefault();

            if(product != null)
            {
                GetCart().AddProduct(product, 1);
            }
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromToCart(int Id)
        {

            var product = db.Products.Where(i => i.Id == Id).FirstOrDefault();

            if (product != null)
            {
                GetCart().DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }


        public Cart GetCart()
        {

            var cart = (Cart)Session["Cart"];
            //session her kullanıcıya özel depo
            if (cart == null)
            {
                cart=new Cart();
                Session["Cart"]= cart;
            }

            return cart;
        }

        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }
      
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }
       
        [HttpPost]
        public ActionResult Checkout(ShippingDetails entity)
        {
            var cart = GetCart();

            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("UrunYokError", "Sepetinizde ürün bulunmamaktadır.");
            }

            if (ModelState.IsValid)
            {
                SaveOrder(cart, entity);
                // Siparişi veritabanına kayıt et.
                //kayıt sonrası cartı sıfırla
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(entity);
            }

            
        }

        private void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var order = new Order();
            order.OrderNumber = "A"+(new Random()).Next(11111,99999).ToString();
            order.Total = cart.Total();
            order.OrderDate= DateTime.Now;
            order.Username=entity.Username;
            order.AdresBasligi=entity.AdresBasligi;
            order.Adres=entity.Adres;
            order.Sehir = entity.Sehir;
            order.Semt = entity.Semt;
            order.Mahalle=entity.Mahalle;
            order.PostaKodu=entity.PostaKodu;
           
            order.OrderLines= new List<OrderLine>();
          
            foreach (var pr in cart.CartLines )
            {
                var orderline=new OrderLine();
                orderline.Quantity=pr.Quantity;
                orderline.Price=pr.Quantity * pr.Product.Price;
                orderline.productId = pr.Product.Id;

                order.OrderLines.Add(orderline);
            }
            db.Orders.Add(order);
            db.SaveChanges();
        }
    }
}