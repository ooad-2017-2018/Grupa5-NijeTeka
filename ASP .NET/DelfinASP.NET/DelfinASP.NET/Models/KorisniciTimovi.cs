using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DelfinASP.NET.Models
{
    public class KorisniciTimovi
    {
        [Required]
        protected string imeTima;
        [Required]
        protected string imeTrenera;
        [Required]
        protected int brojClanova;
        [Required]
        protected DateTime datumOsnivanja;
        [Required]
        protected string korisnickoIme;
        [Required]
        protected string lozinka;
        [ScaffoldColumn(false)]
        public int KorisniciTimoviID{get;set;}

        public KorisniciTimovi() { }
        public KorisniciTimovi(string imeTima, string imeTrenera, int brojClanova,DateTime datum, string korisnickoIme, string lozinka)
        {
            ImeTima = imeTima;
            ImeTrenera = imeTrenera;
            BrojClanova = brojClanova;
            DatumOsnivanja = datum;
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
        }

        public string ImeTima { get => imeTima; set => imeTima = value; }
        public string ImeTrenera { get => imeTrenera; set => imeTrenera = value; }
        public int BrojClanova { get => brojClanova; set => brojClanova = value; }
        public DateTime DatumOsnivanja { get => datumOsnivanja; set => datumOsnivanja = value; }
        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
    }
}