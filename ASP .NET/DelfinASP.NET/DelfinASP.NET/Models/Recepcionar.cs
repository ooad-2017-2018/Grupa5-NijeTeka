using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DelfinASP.NET.Models
{
    public class Recepcionar : Uposlenik
    {
        public Recepcionar(string ime, string prezime, DateTime datumRodjenja, double plata) : base(ime, prezime, datumRodjenja, plata, "recepcionar", "recepcionar") { }

    }
}