using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCCodefirst.Models
{
    public class Ders
    {
        [Key]
        public int DersID { get; set; }

        [Required (ErrorMessage ="Ders Adı ")]
        [DisplayName(" Ders Adı")]
        public string DersAdi { get; set; }

        [DisplayName("Açıklama")] 
        [Column(TypeName ="text")]
        public string Aciklama { get; set; }
    }
}