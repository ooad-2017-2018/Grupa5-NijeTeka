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

namespace DelfinBazen.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PregledEvidencije : Page
    {
        Bazen b;
        
        public PregledEvidencije()
        {
            this.InitializeComponent();
            b = new Bazen();
            
        }
        public PregledEvidencije(ref Bazen bazen)
        {
            this.InitializeComponent();
            b = new Bazen();
            b = bazen;
            foreach (Uposlenik o in b.Uposlenici)
            {
                if (o is Uposlenik) list.Items.Add(o.ToString());
            }

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Page nazad = new UposlenikForma();
            this.Content = nazad;
        }

        

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Uposlenik u in b.Uposlenici)
            {
                
                //Pregled.Text( u.Ime + " " + u.Prezime + " Datum rodjenja: " + Convert.ToString(u.DatumRodjenja) + " Iznos plate: " + Convert.ToString(u.Plata) + " \n");
            }
        }
    }
}
