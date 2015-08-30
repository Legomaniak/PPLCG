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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PPLCG;

namespace CardFiller
{
    /// <summary>
    /// Interaction logic for Spojenec.xaml
    /// </summary>
    public partial class ViewSpojenec : UserControl
    {
        public ViewSpojenec()
        {
            InitializeComponent();
        }
        public PPLCG.DataSpojenec GetData()
        {
            return new PPLCG.DataSpojenec(int.Parse(boxZivoty.Text), int.Parse(boxUtok.Text), int.Parse(boxObrana.Text), int.Parse(boxVule.Text), int.Parse(boxZdroje.Text));
        }
        public void SetData(PPLCG.DataSpojenec karta)
        {
            boxObrana.Text = karta.Obrana.ToString();
            boxUtok.Text = karta.Utok.ToString();
            boxVule.Text = karta.Vule.ToString();
            boxZdroje.Text = karta.Zdroje.ToString();
            boxZivoty.Text = karta.Zivoty.ToString();
        }
    }
}
