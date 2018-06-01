using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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
using Windows.UI.Popups;
using DelfinBazen.ViewModel;
using DelfinBazen.View;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DelfinBazen.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegistracijaPojedincaForma : Page
    {
        Bazen b;
        Regex imeRegex = new Regex("^([^0-9]*)$");
       
        public RegistracijaPojedincaForma()
        {
            this.InitializeComponent();
            b = new Bazen();
        }

        public RegistracijaPojedincaForma(ref Bazen refBazen)
        {
            this.InitializeComponent();
            b = new Bazen();
            b = refBazen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string ime = Ime.Text;
            string prezime = Prezime.Text;
            DateTime datum = cal.Date.Value.Date;
            string JMB = JMBroj.Text;
            string imekorisnicko = Korisnicko.Text;
            string lozinkaprva = Lozinka1.Password.ToString();
            string lozinkadruga = Lozinka2.Password.ToString();
            if (!Validiraj(ime, prezime,datum,JMB, imekorisnicko, lozinkaprva, lozinkadruga))
            {
                PrijavaGreski.Content += "Molimo ispravite greske!";
            }
            else
            {
                KorisnikViewModel kvm = new KorisnikViewModel();
                KorisniciPojedinci kp = kvm.registracija(ime,prezime,datum,JMB,imekorisnicko,lozinkaprva,lozinkadruga);
                b.KorisniciPojedinci.Add(kp);
                var dialog = new MessageDialog("Uspješno ste registrovani!");
                dialog.ShowAsync();
                Page pocetna = new OdabirPaketaForma();
                this.Content = pocetna;

            }
        }

        public bool Validiraj(string ime, string prezime,DateTime datum,string jmbg, string korisnicko, string lozinka1, string lozinka2 )
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
            
            if (lozinka1 != lozinka2)
            {
                PrijavaGreski.Content = "Lozinke se ne podudaraju!";
                return false;
            }

            if (ime == "" || prezime == "" || jmbg == "" || korisnicko == "" || lozinka1 == "" || lozinka2 == "")
            {
                PrijavaGreski.Content = "Niste popunili sva polja";
                return false;
            }
            /*string godina = Convert.ToString(datum.Year);
            if (datum.Day != jmbg[0]+jmbg[1] ) //|| datum.Month!=jmbg[2]+jmbg[3] || "godina[1]"+"godina[2]"+"godina[3]"!="jmbg[4]"+"jmbg[5]"+"jmbg[6]")
            {
                PrijavaGreski.Content = "Neispravan unos datuma i JMB!";
                return false;
            }*/
            return true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Page nazad = new Prijava();
            this.Content = nazad;
        }
    }
}
