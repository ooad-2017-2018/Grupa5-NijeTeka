using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelfinBazen.Model
{
    public class KorisniciTimovi
    {
        private string imeTima;
        private string imeTrenera;
        private int brojClanova;
        //private DateTime datumOsnivanja;
        private string korisnickoIme;
        private string lozinka;

        public KorisniciTimovi(string imeTima, string imeTrenera, int brojClanova,  string korisnickoIme, string lozinka)
        {
            ImeTima = imeTima;
            ImeTrenera = imeTrenera;
            BrojClanova = brojClanova;
            //DatumOsnivanja = datumOsnivanja;
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
        }

        public string ImeTima { get => imeTima; set => imeTima = value; }
        public string ImeTrenera { get => imeTrenera; set => imeTrenera = value; }
        public int BrojClanova { get => brojClanova; set => brojClanova = value; }
        //public DateTime DatumOsnivanja { get => datumOsnivanja; set => datumOsnivanja = value; }
        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
    }
}
