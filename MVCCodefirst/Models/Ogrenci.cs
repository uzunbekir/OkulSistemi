using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCodefirst.Models
{
    public class Ogrenci
    {
        [Key]
        [DisplayName("Ogrenci No")]
        public int OgrenciID { get; set; }

        [Required(ErrorMessage ="Ad soyad zorunludur")]
        [MaxLength(100)] // db tarafı için
        [StringLength (100,MinimumLength =3,ErrorMessage ="Ad soyad 3-100 Krk arası olmalı")]        // ekranlar için 



        //display  name yapıyoruz kulanıcı ne görücek
        [DisplayName("Ad Soyad")]
        public string AdSoyad { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Doğum Tarihi")]
        public DateTime? DogumTarihi { get; set; }
        
        [DisplayName("Mezun mu?")]
        public bool MezunMu { get; set; }

        public double Ortalama { get; set; }




    }
}