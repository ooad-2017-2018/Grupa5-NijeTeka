﻿using System;
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
using System.Text.RegularExpressions;
using DelfinBazen.XamlFileovi;
using Windows.UI.Popups;
using DelfinBazen.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DelfinBazen.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegistracijaGrupeForma : Page
    {
        Bazen b;
        Regex imeRegex = new Regex("^([^0-9]*)$");

        public RegistracijaGrupeForma()
        {
            this.InitializeComponent();
            b = new Bazen();
        }

        public RegistracijaGrupeForma(ref Bazen refBazen)
        {
            this.InitializeComponent();
            b = new Bazen();
            b = refBazen;
        }

        private bool Validiraj(string ime, string trener, int clanovi, string korisnicko, string lozinka1, string lozinka2)
        {
            
            if (!imeRegex.IsMatch(trener))
            {
                Greske.Content = "Neispravno ime i prezime trenera! (Prezime se sastoji samo od slova)";
                return false;
            }

            if (lozinka1 != lozinka2)
            {
                Greske.Content = "Lozinke se ne podudaraju!";
                return false;
            }

            if (ime == "" || trener == "" || clanovi == 0 || korisnicko == "" || lozinka1 == "" || lozinka2 == "")
            {
                Greske.Content = "Niste popunili sva polja";
                return false;
            }
            
            return true;
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string ime = Ime.Text;
            string trener = Trener.Text;
            DateTime datum = DatumOsnivanja.Date.Value.Date;
            int brojCl = Convert.ToInt32(BrojClanova.Text);
            string imekorisnicko = Korisnicko.Text;
            string lozinkaprva = Lozinka1.Password.ToString();
            string lozinkadruga = Lozinka2.Password.ToString();
            if (!Validiraj(ime, trener, brojCl, imekorisnicko, lozinkaprva, lozinkadruga))
            {
                Greske.Content += "Molimo ispravite greske!";
            }
            else
            {
                TimoviViewModel tvm = new TimoviViewModel();
                KorisniciTimovi kt = tvm.rezervisi(ime, trener, brojCl, imekorisnicko, lozinkaprva);
                b.KorisniciTimovi.Add(kt);
                var dialog = new MessageDialog("Uspješno ste registrovani!");
                dialog.ShowAsync();
                Page page = new Pocetna(ref b);
                this.Content = page;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Page nazad = new Pocetna();
            this.Content = nazad;
        }
    }
}
