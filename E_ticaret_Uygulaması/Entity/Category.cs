using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_ticaret_Uygulaması.Entity
{
    public class Category
    {
        public int Id { get; set; }
        //Data annotation denilir bunlarada
        [DisplayName("Kategori Adı")]
        [StringLength(25,ErrorMessage ="En fazla 25 karakter olmalı...")]
        public string Name { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}