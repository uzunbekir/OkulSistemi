using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCodefirst.Models
{
    public class Egitmen
    {
        [Key]
        public int EgitmenID { get; set; }
        [DisplayName("İsim Soyisim")]
        public string AdSoyad { get; set; }

        [DataType(DataType.Date)]
        [DisplayName( "Doğum Tarihi")]
        public DateTime? DogumTarihi { get; set; }

        // null olduğunda hata vermesin diye ? kullanıyorum
    }
}