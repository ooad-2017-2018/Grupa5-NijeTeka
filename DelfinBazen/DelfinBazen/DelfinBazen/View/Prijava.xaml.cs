using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using DelfinBazen.Model;
using DelfinBazen.XamlFileovi;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DelfinBazen.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Prijava : Page
    {
        Bazen b;
        public Prijava()
        {
            this.InitializeComponent();
            b = new Bazen();
        }
        public Prijava(ref Bazen bazen)
        {
            this.InitializeComponent();
            b = new Bazen();
            b = bazen;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Upravitelj u = new Upravitelj("Senad", "Senci", Convert.ToDateTime("12.02.1990."), 152.2);
            b.Uposlenici.Add(u);
            string ime = Ime.Text;
            string lozinka = Lozinka.Password.ToString();
            bool var = false;
            foreach(KorisniciPojedinci kp in b.KorisniciPojedinci)
            {
                if(ime==kp.KorisnickoIme && lozinka == kp.Lozinka)
                {
                    var = true;
                    Page paketi = new OdabirPaketaForma();
                    this.Content = paketi;
                }
            }
            foreach (KorisniciTimovi kt in b.KorisniciTimovi)
            {
                if (ime == kt.KorisnickoIme && lozinka == kt.Lozinka)
                {
                    var = true;
                    Page paketi = new RezervacijaTim();
                    this.Content = paketi;
                }
            }
            if (var == false)
            {
                Greska.Content = "Neispravni podaci! Ako niste registrovani, molimo vas da se registrujete!";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Page registracija = new RegistracijaPojedincaForma();
            this.Content = registracija;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Page registracija2 = new RegistracijaGrupeForma();
            this.Content = registracija2;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Page nazad = new Pocetna();
            this.Content = nazad;
        }
    }
}
