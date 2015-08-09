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
    /// Interaction logic for Zrada.xaml
    /// </summary>
    public partial class Zrada : UserControl
    {
        public Zrada()
        {
            InitializeComponent();
        }
        public void Init(List<string> stiny)
        {
            myListControl1.data = stiny;
        }
        public void SetData(PPLCG.DataZrada karta)
        {
            foreach (string s in karta.Stin)
                myListControl1.Add(s);
        }
        public PPLCG.DataZrada GetData()
        {
            return new PPLCG.DataZrada(myListControl1.GetSelected().ToArray());
        }
    }
}
