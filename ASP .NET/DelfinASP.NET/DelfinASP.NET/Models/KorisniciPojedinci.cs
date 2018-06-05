using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DelfinASP.NET.Models
{
    public class KorisniciPojedinci
    {
        [Required]
        protected string ime;
        [Required]
        protected string prezime;
        protected string jmbg;
        [Required]
        protected DateTime datumRodjenja;
        [Required]
        protected string korisnickoIme;
        [Required]
        protected string lozinka;
        [ScaffoldColumn(false)]
        public int KorisniciPojedinciID { get; set; }
        public KorisniciPojedinci(string ime, string prezime, string jMBG,DateTime datum, string korisnickoIme, string lozinka)
        {
            Ime = ime;
            Prezime = prezime;
            JMBG = jmbg;
            DatumRodjenja = datum;
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
        }

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string JMBG { get => jmbg; set => jmbg = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
    }
}