using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelfinBazen.Model
{
    public class Upravitelj : Uposlenik
    {
        public Upravitelj(string ime, string prezime, DateTime datumRodjenja, double plata) : base(ime, prezime, datumRodjenja, plata) { }
    }
}
