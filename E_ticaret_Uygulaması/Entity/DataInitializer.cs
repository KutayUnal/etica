using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;

namespace E_ticaret_Uygulaması.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>//eğer model değişmişse veri  tabanını oluşturucak bu işlem
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>()

            {
                new Category(){Name="Kamera",Description="kameranın özellikleri",},
                new Category() { Name = "TV", Description = "TV özellikleri" },
                new Category() { Name = "PC", Description = "Pc özellikleri" },
                new Category(){Name="Telefon",Description="Telefon özellikleri"},
                new Category(){Name="Beyaz eşya",Description="Beyaz eşya özellikleri"},
            };
            //test verilerini yapıyoruz

            foreach (var x in kategoriler) 
            {
             context.Categories.Add(x);
                //kategorileri ekliyoruz
            }
            context.SaveChanges();
            var ürünler = new List<Product>()
            {
                new Product(){Name="Sony Zv-1 Vlog Dijital Fotoğraf Makinesi",Description="20.1MP 1 Exmor RS BSI CMOS SensörZEISS 24-70mm-Eşdeğ. f / 1.8-2.8 MercekUHD 4K Video kaydı",Price=8000,Stock=5,IsApproved=true,CategoryId=1,IsHome=true,Image="1.jpg"},//IsHome true olanlar ana sayfada yayınlanacak vermezsen false olur yayınlanmaz
                new Product(){Name="CANON EOS R50 ",Description="20.1MP 1 Exmor RS BSI CMOS SensörZEISS 24-70mm-Eşdeğ. f / 1.8-2.8 MercekUHD 4K Video kaydı",Price=5000,Stock=5,IsApproved=true,CategoryId=1,IsHome=true,Image="1.jpg"},
                new Product(){Name="Nikon Z50",Description="Toplam çözünürlük: 20 megapixel Fotoğraf çözünürlüğü: 21.51 milyon",Price=9000,Stock=5,IsApproved=true,CategoryId=1,Image="1.jpg"},
                new Product(){Name="Sony Zv-5 Vlog Dijital Fotoğraf Makinesi",Description="15.1MP 1 Exmor RS BSI CMOS Sensör",Price=3760,Stock=5,IsApproved=true,CategoryId=1,IsHome=true,Image="1.jpg"} ,
                new Product(){Name="PHILIPS ",Description="Ürün Tipi: Ambilight TV Ekran Tipi: LED Ekran boyutu(cm): 139 cm",Price=23333,Stock=0,IsApproved=false,CategoryId=2,IsHome=true,Image="2.jpg"},
                new Product(){Name="LG ",Description="Ürün Tipi: Ambilight TV Ekran Tipi: LED Ekran boyutu(cm): 139 cm",Price=23333,Stock=1111,IsApproved=true,CategoryId=2,IsHome=true,Image="2.jpg"},
                new Product(){Name="SAMSUNG ",Description="Ürün Tipi: Ambilight TV Ekran Tipi: LED Ekran boyutu(cm): 139 cm",Price=23333,Stock=37,IsApproved=true,CategoryId=2,Image="2.jpg"},
                new Product(){Name="ASUS ",Description="24 INC 8 GB RAM",Price=23333,Stock=37,IsApproved=true,CategoryId=3,Image="3.jpg"},
                new Product(){Name="MSI ",Description="14 INC 16 GB RAM",Price=11111,Stock=0,IsApproved=false,CategoryId=3,IsHome=true,Image="3.jpg"},
                new Product(){Name="MONSTER ",Description="OYUN CANAVARII",Price=22222,Stock=37,IsApproved=true,CategoryId=3,Image="4.jpg"},
                new Product(){Name="LG ",Description="İşlemci Hızı:0.65 GHzİşlemci Türü:lg",Price=2000,Stock=37,IsApproved=true,CategoryId=4,IsHome=true,Image="2.jpg"},
                new Product(){Name="SAMSUNG ",Description="İşlemci Hızı:1.65 GHzİşlemci Türü:samsung",Price=5000,Stock=0,IsApproved=false,CategoryId=4,Image="2.jpg"},
                new Product(){Name="APPLE ",Description="İşlemci Hızı:2.65 GHzİşlemci Türü:Apple",Price=1000,Stock=37,IsApproved=true,CategoryId=4,IsHome=true,Image="2.jpg"},
                new Product(){Name="ARÇELİK ",Description="buzdolabı ",Price=30000,Stock=37,IsApproved=true,CategoryId=5},
                new Product(){Name="BEKO ",Description="Çamaşır Mak.",Price=27000,Stock=0,IsApproved=false,CategoryId=5},
                new Product(){Name="BOSCH ",Description="Bulaşık Mak.",Price=15000,Stock=37,IsApproved=true,CategoryId=5},
            };
            foreach (var o in ürünler)
            {
                context.Products.Add(o);
                //ürünleri tek tet foreachle ekliyoruz
            }
            context.SaveChanges();  
            base.Seed(context);
        }
    }
}