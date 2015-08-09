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

namespace CardFiller
{
    /// <summary>
    /// Interaction logic for Udalost.xaml
    /// </summary>
    public partial class Udalost : UserControl
    {
        public Udalost()
        {
            InitializeComponent();
        }
        public PPLCG.DataUdalost GetData()
        {
            return new PPLCG.DataUdalost(int.Parse(boxCena.Text));
        }
        public void SetData(PPLCG.DataUdalost karta)
        {
            boxCena.Text = karta.Cena.ToString();
        }
    }
}
