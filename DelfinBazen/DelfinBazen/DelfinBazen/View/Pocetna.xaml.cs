using DelfinBazen.Model;
using DelfinBazen.View;
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
    public sealed partial class Pocetna : Page
    {
        Bazen b;

        public Pocetna()
        {
            this.InitializeComponent();
            b = new Bazen();
        }
        public Pocetna(ref Bazen bazen)
        {
            this.InitializeComponent();
            b = new Bazen();
            b = bazen;
        }
        
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Page stranica = new Prijava(ref b);
            this.Content = stranica;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Page prijava1 = new RegistracijaPojedincaForma(ref b);
            this.Content = prijava1;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Page prijava2 = new RegistracijaGrupeForma(ref b);
            this.Content = prijava2;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Page stranica = new Prijava(ref b);
            this.Content = stranica;
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
