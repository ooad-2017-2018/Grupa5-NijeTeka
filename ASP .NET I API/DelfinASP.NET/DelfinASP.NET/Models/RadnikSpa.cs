using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DelfinASP.NET.Models
{
    public class RadnikSpa:Uposlenik
    {
        [ScaffoldColumn(false)]
        public int RadnikSpaID { get; set; }

        public RadnikSpa() { }
        public RadnikSpa(string ime, string prezime, DateTime datumRodjenja, double plata) : base(ime, prezime, datumRodjenja, plata, "spacentar", "spacentar") { }
    }
}