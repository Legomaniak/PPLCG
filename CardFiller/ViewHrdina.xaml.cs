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
    /// Interaction logic for Hrdina.xaml
    /// </summary>
    public partial class ViewHrdina : UserControl
    {
        public ViewHrdina()
        {
            InitializeComponent();
        }
        public PPLCG.DataHrdina GetData()
        {
            return new PPLCG.DataHrdina(int.Parse(boxZivoty.Text), int.Parse(boxUtok.Text), int.Parse(boxObrana.Text), int.Parse(boxVule.Text), int.Parse(boxHrozba.Text));
        }
        public void SetData(PPLCG.DataHrdina karta)
        {
            boxObrana.Text = karta.Obrana.ToString();
            boxUtok.Text = karta.Utok.ToString();
            boxVule.Text = karta.Vule.ToString();
            boxHrozba.Text = karta.Hrozba.ToString();
            boxZivoty.Text = karta.Zivoty.ToString();
        }
    }
}
