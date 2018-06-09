using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DelfinASP.NET.Models
{
    public class DelfinBazen
    {
        List<KorisniciPojedinci> korisniciPojedinci = new List<KorisniciPojedinci>();
        List<KorisniciTimovi> korisniciTimovi = new List<KorisniciTimovi>();
        List<Uposlenik> uposlenici = new List<Uposlenik>();
        
        public List<KorisniciPojedinci> KorisniciPojedinci { get => korisniciPojedinci; set => korisniciPojedinci = value; }
        public List<KorisniciTimovi> KorisniciTimovi { get => korisniciTimovi; set => korisniciTimovi = value; }
        public List<Uposlenik> Uposlenici { get => uposlenici; set => uposlenici = value; }
        


        private void dodajKorisnika(KorisniciPojedinci k)
        {
            korisniciPojedinci.Add(k);
        }
        private void dodajTim(KorisniciTimovi kt)
        {
            korisniciTimovi.Add(kt);
        }
        
        private void dodajUposlenika(Uposlenik u)
        {
            uposlenici.Add(u);
        }
    }
}