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
            string ime = Ime.Text;
            string lozinka = Lozinka.Text;
            foreach(KorisniciPojedinci kp in b.KorisniciPojedinci)
            {
                if(ime==kp.KorisnickoIme && lozinka == kp.Lozinka)
                {
                    Page paketi = new OdabirPaketaForma();
                    this.Content = paketi;
                }
            }
            Greska.Content = "Neispravni podaci! Ako niste registrovani, molimo vas da se registrujete!";
        }
    }
}
