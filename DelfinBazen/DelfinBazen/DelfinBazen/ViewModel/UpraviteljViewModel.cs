using DelfinBazen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace DelfinBazen.ViewModel
{
    public class UpraviteljViewModel : Page
    {
        public UpraviteljViewModel()
        {

        }

        public Recepcionar dodajRecepcionara(string ime, string prezime, DateTime datum ,double plata)
        {
            Recepcionar r = new Recepcionar(ime, prezime,datum, plata);
            return r;
        }

        public Upravitelj dodajUpravitelja(string ime, string prezime, DateTime datum, double plata)
        {
            Upravitelj u = new Upravitelj(ime, prezime, datum, plata);
            return u;
        }

        public RadnikSpa dodajSpaRadnika(string ime, string prezime, DateTime datum, double plata)
        {
            RadnikSpa r = new RadnikSpa(ime, prezime, datum, plata);
            return r;
        }

        public Zastitar dodajZastitara(string ime, string prezime, DateTime datum, double plata)
        {
            Zastitar z = new Zastitar(ime, prezime, datum, plata);
            return z;
        }
    }
}
