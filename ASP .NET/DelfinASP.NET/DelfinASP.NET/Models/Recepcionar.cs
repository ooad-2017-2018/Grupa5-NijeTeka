using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DelfinASP.NET.Models
{
    public class Recepcionar : Uposlenik
    {
        [ScaffoldColumn(false)]
        public int RecepcionarID { get; set; }
        public Recepcionar(string ime, string prezime, DateTime datumRodjenja, double plata) : base(ime, prezime, datumRodjenja, plata, "recepcionar", "recepcionar") { }

    }
}