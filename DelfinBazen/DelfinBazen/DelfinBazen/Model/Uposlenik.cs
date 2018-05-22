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
        private string korisnickoIme;
        private string lozinka;

        public Uposlenik(string ime, string prezime, DateTime datumRodjenja, double plata, string korisnickoIme, string lozinka)
        {
            Ime = ime;
            Prezime = prezime;
            DatumRodjenja = datumRodjenja;
            Plata = plata;
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
        }

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public double Plata { get => plata; set => plata = value; }
        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
    }
}
