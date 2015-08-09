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
    /// Interaction logic for Karta.xaml
    /// </summary>
    public partial class Karta : UserControl
    {
        public Karta()
        {
            InitializeComponent();
            foreach (string s in Enum.GetNames(typeof(PPLCG.Typy)))
            {
                boxTyp.Items.Add(s);
            }
            boxTyp.SelectedIndex = 0;
            foreach (string s in Enum.GetNames(typeof(PPLCG.Sfery)))
            {
                boxSfera.Items.Add(s);
            }
            boxSfera.SelectedIndex = 0;
        }
        List<string> stiny = new List<string>();
        public void Init(List<string> reakce, List<string> stiny)
        {
            myListControl1.data = reakce;
            this.stiny = stiny;
        }
        public PPLCG.IKarta GetKarta()
        {
           PPLCG.DataKarta dataKarta = new PPLCG.DataKarta(boxId.Text, boxJmeno.Text, boxPopis.Text, (PPLCG.Sfery)boxSfera.SelectedIndex, (PPLCG.Typy)boxTyp.SelectedIndex, boxKvalita.IsChecked.Value, myListControl1.GetSelected().ToArray(), (string)boxDruh.Text, new PPLCG.Citace(boxCitace.Text, boxAutor.Text));
           PPLCG.IKarta karta = null;
           switch (dataKarta.Typ)
           {
               case PPLCG.Typy.Doplnek: karta = new PPLCG.KartaDoplnek() { Karta = dataKarta, Doplnek = (grid1.Children[0] as Doplnek).GetData() };
                   break;
               case PPLCG.Typy.Hrdina: karta = new PPLCG.KartaHrdina() { Karta = dataKarta, Hrdina = (grid1.Children[0] as Hrdina).GetData() };
                   break;
               case PPLCG.Typy.Lokace: karta = new PPLCG.KartaLokace() { Karta = dataKarta, Lokace = (grid1.Children[0] as Lokace).GetData() };
                   break;
               case PPLCG.Typy.Nepritel: karta = new PPLCG.KartaNepritel() { Karta = dataKarta, Nepritel = (grid1.Children[0] as Nepritel).GetData() };
                   break;
               case PPLCG.Typy.Spojenec: karta = new PPLCG.KartaSpojenec() { Karta = dataKarta, Spojenec = (grid1.Children[0] as Spojenec).GetData() };
                   break;
               case PPLCG.Typy.Udalost: karta = new PPLCG.KartaUdalost() { Karta = dataKarta, Udalost = (grid1.Children[0] as Udalost).GetData() };
                   break;
               case PPLCG.Typy.Zrada: karta = new PPLCG.KartaZrada() { Karta = dataKarta, Zrada = (grid1.Children[0] as Zrada).GetData() };
                   break;
           }

           return karta;
        }
        public void SetKarta(PPLCG.IKarta karta)
        {
            PPLCG.DataKarta k = karta.Karta;
            boxId.Text = k.Id;
            boxJmeno.Text = k.Jmeno;
            boxPopis.Text = k.Popis;
            boxCitace.Text = k.Citace.Text;
            boxAutor.Text = k.Citace.Autor;
            boxDruh.SelectedItem = k.Druh;
            boxSfera.SelectedIndex = (int)k.Sfera;
            boxTyp.SelectedIndex = (int)k.Typ;
            foreach (string s in k.Reakce)
                myListControl1.Add(s);
            //boxKvalita.Dispatcher.BeginInvoke((Action)(() =>
            //{
                boxKvalita.IsChecked = k.Kvalita;
            //}));

                switch (karta.Karta.Typ)
                {
                    case PPLCG.Typy.Doplnek: (grid1.Children[0] as Doplnek).SetData((karta as PPLCG.KartaDoplnek).Doplnek); 
                        break;
                    case PPLCG.Typy.Hrdina: (grid1.Children[0] as Hrdina).SetData((karta as PPLCG.KartaHrdina).Hrdina); 
                        break;
                    case PPLCG.Typy.Lokace: (grid1.Children[0] as Lokace).SetData((karta as PPLCG.KartaLokace).Lokace); 
                        break;
                    case PPLCG.Typy.Nepritel: (grid1.Children[0] as Nepritel).SetData((karta as PPLCG.KartaNepritel).Nepritel); 
                        break;
                    case PPLCG.Typy.Spojenec: (grid1.Children[0] as Spojenec).SetData((karta as PPLCG.KartaSpojenec).Spojenec); 
                        break;
                    case PPLCG.Typy.Udalost: (grid1.Children[0] as Udalost).SetData((karta as PPLCG.KartaUdalost).Udalost); 
                        break;
                    case PPLCG.Typy.Zrada: (grid1.Children[0] as Zrada).SetData((karta as PPLCG.KartaZrada).Zrada); 
                        break;
                }
        }

        private void boxTyp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            grid1.Children.Clear();
            // Spojenec, Doplnek, Udalost, Lokace, Zrada, Nepritel, Hrdina
            switch (boxTyp.SelectedIndex)
            {
                case 0:
                    grid1.Children.Add(new Spojenec());
                    break;
                case 1:
                    grid1.Children.Add(new Doplnek());
                    break;
                case 2:
                    grid1.Children.Add(new Udalost());
                    break;
                case 3:
                    Lokace l = new Lokace();
                    l.Init(stiny);
                    grid1.Children.Add(l);
                    break;
                case 4:
                    Zrada z = new Zrada();
                    z.Init(stiny);
                    grid1.Children.Add(z);
                    break;
                case 5:
                    Nepritel n = new Nepritel();
                    n.Init(stiny);
                    grid1.Children.Add(n);
                    break;
                case 6:
                    grid1.Children.Add(new Hrdina());
                    break;
            }
        }
    }
}
