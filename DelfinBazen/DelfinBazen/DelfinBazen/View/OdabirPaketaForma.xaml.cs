using DelfinBazen.Model;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace DelfinBazen.XamlFileovi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OdabirPaketaForma : Page
    {
        Bazen b;
        public OdabirPaketaForma()
        {
            this.InitializeComponent();
            b = new Bazen();
        }
        public OdabirPaketaForma(ref Bazen bazen)
        {
            this.InitializeComponent();
            b = new Bazen();
            b = bazen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string vrsta="";
            int cijena = 0;
            DateTime datum = Convert.ToDateTime(Termin);
            Termin termin = new Termin(datum);
            if (Paket1.IsChecked == true)
            {
                vrsta = Convert.ToString(Paket1);
                cijena += 10;
            }
            else if (Paket2.IsChecked == true)
            {
                vrsta = Convert.ToString(Paket2);
                cijena += 20;
            }
            else if (Paket3.IsChecked == true)
            {
                vrsta = Convert.ToString(Paket3);
                if (Masaza1.IsChecked == true) cijena += 35;
                else if (Masaza2.IsChecked == true) cijena += 40;
                else if (Masaza3.IsChecked == true) cijena += 60;
                else if (Masaza4.IsChecked == true) cijena += 50;
            }

            if (Papuce.IsChecked == true) cijena += 2;
            if (Peskir.IsChecked == true) cijena += 3;
            if (Ormaric.IsChecked == true) cijena += 5;
            foreach(Termin t in b.Termini)
            {
                if (t == termin) Greska.Content = "Termin je popunjen";
                
            }
            Greska.Content = "Uspjesno ste rezervisali uslugu!";
            b.Paketi.Add(new Paket(vrsta, cijena));
            Page Pocetna = new Pocetna(ref b);
            this.Content = Pocetna;

        }
    }
}
