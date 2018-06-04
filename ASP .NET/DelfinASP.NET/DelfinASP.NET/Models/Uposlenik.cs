using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DelfinASP.NET.Models
{
    public class Uposlenik
    {

        [Required]
        protected string ime;
        [Required]
        protected string prezime;
        [Required]
        protected DateTime datumRodjenja;
        [Required]
        protected double plata;
        [Required]
        protected string korisnickoIme;
        [Required]
        protected string lozinka;

        public Uposlenik() { }

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