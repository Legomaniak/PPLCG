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
    /// Interaction logic for Nepritel.xaml
    /// </summary>
    public partial class Nepritel : UserControl
    {
        public Nepritel()
        {
            InitializeComponent();
        }
        public void Init(List<string> stiny)
        {
            myListControl1.data = stiny;
        }
        public PPLCG.DataNepritel GetData()
        {
            return new PPLCG.DataNepritel(myListControl1.GetSelected().ToArray(), int.Parse(boxZivoty.Text), int.Parse(boxUtok.Text), int.Parse(boxObrana.Text), int.Parse(boxOhrozeni.Text), int.Parse(boxStretnuti.Text));
        }
        public void SetData(PPLCG.DataNepritel karta)
        {
            boxObrana.Text = karta.Obrana.ToString();
            boxUtok.Text = karta.Utok.ToString();
            boxOhrozeni.Text = karta.Ohrozeni.ToString();
            boxStretnuti.Text = karta.Stretnuti.ToString();
            boxZivoty.Text = karta.Zivoty.ToString();
            foreach (string s in karta.Stin) myListControl1.Add(s);
        }
    }
}
