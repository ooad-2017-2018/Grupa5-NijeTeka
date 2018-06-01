using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelfinBazen.Model
{
    public class KorisniciPojedinci
    {
        private string ime;
        private string prezime;
        private string jmbg;
        //private DateTime datumRodjenja;
        private string korisnickoIme;
        private string lozinka;

        public KorisniciPojedinci(string ime, string prezime, string jMBG,  string korisnickoIme, string lozinka)
        {
            Ime = ime;
            Prezime = prezime;
            JMBG = jmbg;
            //DatumRodjenja = datumRodjenja;
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
        }

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string JMBG { get => jmbg; set => jmbg = value; }
        //public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
    }
}
