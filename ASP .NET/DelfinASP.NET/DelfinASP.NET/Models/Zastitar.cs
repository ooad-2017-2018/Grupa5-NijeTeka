using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DelfinASP.NET.Models
{
    public class Zastitar : Uposlenik
    {
        [ScaffoldColumn(false)]
        public int ZastitarID { get; set; }
        public Zastitar(string ime, string prezime, DateTime datumRodjenja, double plata) : base(ime, prezime, datumRodjenja, plata, "zastitar", "zastitar") { }
    }
}