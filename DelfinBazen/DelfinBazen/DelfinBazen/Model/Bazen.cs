using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelfinBazen.Model
{
    public class Bazen
    {
        List<KorisniciPojedinci> korisniciPojedinci =new List<KorisniciPojedinci>();
        List<KorisniciTimovi> korisniciTimovi = new List<KorisniciTimovi>();
        List<Uposlenik> uposlenici = new List<Uposlenik>();
        List<Paket> paketi = new List<Paket>();
        List<Termin> termini = new List<Termin>();
        public List<KorisniciPojedinci> KorisniciPojedinci { get => korisniciPojedinci; set => korisniciPojedinci = value; }
        public List<KorisniciTimovi> KorisniciTimovi { get => korisniciTimovi; set => korisniciTimovi = value; }
        public List<Uposlenik> Uposlenici { get => uposlenici; set => uposlenici = value; }
        public List<Paket> Paketi { get => paketi; set => paketi = value; }
        public List<Termin> Termini { get => termini; set => termini = value; }
        
        
        private void dodajKorisnika(KorisniciPojedinci k)
        {
            korisniciPojedinci.Add(k);
        }
        private void dodajTim(KorisniciTimovi kt)
        {
            korisniciTimovi.Add(kt);
        }
        private void dodajPaket(Paket p)
        {
            paketi.Add(p);
        }
        private void dodajUposlenika(Uposlenik u)
        {
            uposlenici.Add(u);
        }
    }
}
