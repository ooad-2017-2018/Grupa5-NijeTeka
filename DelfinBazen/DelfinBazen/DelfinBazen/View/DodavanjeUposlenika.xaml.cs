using DelfinBazen.Model;
using DelfinBazen.ViewModel;
using DelfinBazen.XamlFileovi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DelfinBazen.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DodavanjeUposlenika : Page
    {
        Bazen b;
        Regex imeRegex = new Regex("^([^0-9]*)$");
        public DodavanjeUposlenika()
        {
            this.InitializeComponent();
            b = new Bazen();
        }
        public DodavanjeUposlenika(ref Bazen bazen)
        {
            this.InitializeComponent();
            b = new Bazen();
            b = bazen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string imeRadnika = ime.Text;
            string prezimeRadnika = prezime.Text;
            DateTime Datum = datum.Date.Value.Date;
            double plataa = Convert.ToDouble(plata.Text);
            UpraviteljViewModel uvm = new UpraviteljViewModel();
            if (!Validiraj(imeRadnika, prezimeRadnika, Datum, plataa))
            {
                PrijavaGreski.Content += "Unesite ponovo!";
            }
            else
            {
                if (recepcionar.IsChecked == true)
                {
                    Recepcionar r = uvm.dodajRecepcionara(imeRadnika, prezimeRadnika, Datum, plataa);
                    b.Uposlenici.Add(r);
                }
                else if (upravitelj.IsChecked == true)
                {
                    Upravitelj u = uvm.dodajUpravitelja(imeRadnika, prezimeRadnika, Datum, plataa);
                    b.Uposlenici.Add(u);
                }
                else if (sparadnik.IsChecked == true)
                {
                    RadnikSpa r = uvm.dodajSpaRadnika(imeRadnika, prezimeRadnika, Datum, plataa);
                    b.Uposlenici.Add(r);
                }
                else if (zastitar.IsChecked == true)
                {
                    Zastitar z = uvm.dodajZastitara(imeRadnika, prezimeRadnika, Datum, plataa);
                    b.Uposlenici.Add(z);
                }
                var dialog = new MessageDialog("Uspješno ste dodali uposlenika!");
                dialog.ShowAsync();
                Page pocetna = new UposlenikForma();
                this.Content = pocetna;
            }
        }

        public bool Validiraj(string ime, string prezime, DateTime datum, double plata)
        {
            if (!imeRegex.IsMatch(ime))
            {
                PrijavaGreski.Content = "Neispravno ime! (ime se sastoji samo od slova)";
                return false;
            }
            if (!imeRegex.IsMatch(prezime))
            {
                PrijavaGreski.Content = "Neispravno prezime! (Prezime se sastoji samo od slova)";
                return false;
            }

            if (ime == "" || prezime == "" || plata == 0)
            {
                PrijavaGreski.Content = "Niste popunili sva polja";
                return false;
            }
            return true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Page nazad = new UposlenikForma();
            this.Content = nazad;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Page nazad = new UposlenikForma();
            this.Content = nazad;
        }
    }
}
