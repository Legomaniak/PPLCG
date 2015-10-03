using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CardFiller
{
    /// <summary>
    /// Interaction logic for KartaVyber.xaml
    /// </summary>
    public partial class KartaVyber : Window
    {
        public KartaVyber()
        {
            InitializeComponent();
        }
        public AKarta Karta;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (doplek.IsChecked.Value) Karta = new KartaDoplnek(new PPLCG.DataDoplnek());
            else if (hrdina.IsChecked.Value) Karta = new KartaHrdina(new PPLCG.DataHrdina());
            else if (lokace.IsChecked.Value) Karta = new KartaLokace(new PPLCG.DataLokace());
            else if (nepritel.IsChecked.Value) Karta = new KartaNepritel(new PPLCG.DataNepritel()); 
            else if (spojenec.IsChecked.Value) Karta = new KartaSpojenec(new PPLCG.DataSpojenec());
            else if (udalost.IsChecked.Value) Karta = new KartaUdalost(new PPLCG.DataUdalost()); 
            else if (zrada.IsChecked.Value) Karta = new KartaZrada(new PPLCG.DataZrada());
            DialogResult = true;
            Close();
        }
    }
}
