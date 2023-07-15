using E_ticaret_Uygulaması.Entity;
using E_ticaret_Uygulaması.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_ticaret_Uygulaması.Controllers
{
    public class HomeController : Controller
    {
        DataContext context=new DataContext();


        // GET: Home
        public ActionResult Index()
        {
            var urunler= context.Products.Where(i=>i.IsHome && i.IsApproved).Select(i=> new ProductModel()
            {
                Id= i.Id,
                Name= i.Name,
                Description= i.Description.Length>50? i.Description.Substring(0,45)+"...": i.Description,
                Price=i.Price,
                Stock=i.Stock,
                Image=i.Image,
                CategoryId=i.CategoryId,
            }).ToList();
            
            return View(urunler);
            //kayıtlardan IsHome ve IsApproved i true olanlar ana sayfada gözukucek
        }

        public ActionResult Details(int id)
        {
            return View(context.Products.Where(i => i.Id== id ).FirstOrDefault());
            //firstordefault geriye gönderilecek değer 1 tane oldugunu söluyor
            //.Tolist yaptık olmadı
        }
        public ActionResult List(int? id)
            //int? null da gelebilir anlamında
        {
            var urunler = context.Products.Where(i => i.IsApproved).Select(i => new ProductModel() //ısApproved onaylıları getır
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 45) + "..." : i.Description,
                Price = i.Price,
                Stock = i.Stock,
                Image = i.Image,
                CategoryId = i.CategoryId,
            }).AsQueryable();//Asqueryablenin mantıgı vt sorgunun daha çalışmadıgını anlamında
            if(id!=null)
            {
               urunler=urunler.Where(i => i.CategoryId== id);
                // burda id dolu gelmişse bura calısıcak
            }
            
            return View(urunler.ToList());
            // sadece onaylı urunler lıste gelıcek
        }

        public PartialViewResult GetCategories()
        {
            return PartialView(context.Categories.ToList());
        }
    }
}