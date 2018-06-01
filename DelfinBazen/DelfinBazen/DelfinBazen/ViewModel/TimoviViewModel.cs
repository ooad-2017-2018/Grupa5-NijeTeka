using DelfinBazen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace DelfinBazen.ViewModel
{
    public class TimoviViewModel  : Page
    {
        public TimoviViewModel() { }

        public KorisniciTimovi rezervisi(string ime, string trener, int brojCl, string imekorisnicko, string lozinkadruga)
        {
            KorisniciTimovi kt = new KorisniciTimovi(ime, trener, brojCl, imekorisnicko, lozinkadruga);
            return kt;
        }
    }
}
