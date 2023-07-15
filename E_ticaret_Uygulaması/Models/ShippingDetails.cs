using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_ticaret_Uygulaması.Models
{
    public class ShippingDetails
    {
        //Sipariş Teslimat Formu
        public string Username { get; set; }

        [Required (ErrorMessage ="Lütfen adres tanımını giriniz.")]
        public string AdresBasligi { get; set; }
       
        [Required(ErrorMessage = "Lütfen adres giriniz.")]
        public string Adres { get; set; }
       
        [Required(ErrorMessage = "Lütfen sehir giriniz.")]
        public string Sehir { get; set; }
      
        [Required(ErrorMessage = "Lütfen semt giriniz.")]
        public string Semt { get; set; }
      
        [Required(ErrorMessage = "Lütfen mahalle giriniz.")]
        public string Mahalle { get; set; }
       
        public string PostaKodu { get; set; }
        
    }
}