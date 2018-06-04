using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DelfinASP.NET.Models
{
    public class RadnikSpa:Uposlenik
    {
        public RadnikSpa(string ime, string prezime, DateTime datumRodjenja, double plata) : base(ime, prezime, datumRodjenja, plata, "spacentar", "spacentar") { }
    }
}