using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelfinBazen.Model
{
    public class Uposlenik
    {
        private string ime;
        private string prezime;
        private DateTime datumRodjenja;
        private double plata;

        public Uposlenik(string ime, string prezime, DateTime datumRodjenja, double plata)
        {
            Ime = ime;
            Prezime = prezime;
            DatumRodjenja = datumRodjenja;
            Plata = plata;
        }

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public double Plata { get => plata; set => plata = value; }
    }
}
