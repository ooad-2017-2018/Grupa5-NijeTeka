using DelfinBazen.Model;
using DelfinBazen.View;
using DelfinBazen.XamlFileovi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace DelfinBazen.ViewModel
{
    public sealed class KorisnikViewModel :Page
    {
        public KorisnikViewModel() { }

        public KorisniciPojedinci registracija(string ime, string prezime, DateTime datum, string jmbg, string korisnicko, string lozinka1, string lozinka2)
        {

                KorisniciPojedinci kp = new KorisniciPojedinci(ime, prezime, jmbg, korisnicko, lozinka2);
                return kp;
            
        }
        public Paket odabirPaketa(string vrsta, int cijena)
        {
            Paket p = new Paket(vrsta, cijena);
            return p;
        }
    }
}
