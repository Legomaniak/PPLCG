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
    public partial class ViewKarta : UserControl
    {
        public ViewKarta()
        {
            InitializeComponent();
            foreach (string s in Enum.GetNames(typeof(PPLCG.ETypy)))
            {
                boxTyp.Items.Add(s);
            }
            boxTyp.SelectedIndex = 0;
            foreach (string s in Enum.GetNames(typeof(PPLCG.ESfery)))
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
           PPLCG.DataKarta dataKarta = new PPLCG.DataKarta(boxId.Text, boxJmeno.Text, boxPopis.Text, (PPLCG.ESfery)boxSfera.SelectedIndex, (PPLCG.ETypy)boxTyp.SelectedIndex, boxKvalita.IsChecked.Value, myListControl1.GetSelected().ToArray(), (string)boxDruh.Text, new PPLCG.Citace(boxCitace.Text, boxAutor.Text));
           PPLCG.IKarta karta = null;
           switch (dataKarta.Typ)
           {
               case PPLCG.ETypy.Doplnek: karta = new PPLCG.KartaDoplnek() { Karta = dataKarta, Doplnek = (grid1.Children[0] as ViewDoplnek).GetData() };
                   break;
               case PPLCG.ETypy.Hrdina: karta = new PPLCG.KartaHrdina() { Karta = dataKarta, Hrdina = (grid1.Children[0] as ViewHrdina).GetData() };
                   break;
               case PPLCG.ETypy.Lokace: karta = new PPLCG.KartaLokace() { Karta = dataKarta, Lokace = (grid1.Children[0] as ViewLokace).GetData() };
                   break;
               case PPLCG.ETypy.Nepritel: karta = new PPLCG.KartaNepritel() { Karta = dataKarta, Nepritel = (grid1.Children[0] as ViewNepritel).GetData() };
                   break;
               case PPLCG.ETypy.Spojenec: karta = new PPLCG.KartaSpojenec() { Karta = dataKarta, Spojenec = (grid1.Children[0] as ViewSpojenec).GetData() };
                   break;
               case PPLCG.ETypy.Udalost: karta = new PPLCG.KartaUdalost() { Karta = dataKarta, Udalost = (grid1.Children[0] as ViewUdalost).GetData() };
                   break;
               case PPLCG.ETypy.Zrada: karta = new PPLCG.KartaZrada() { Karta = dataKarta, Zrada = (grid1.Children[0] as ViewZrada).GetData() };
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
                    case PPLCG.ETypy.Doplnek: (grid1.Children[0] as ViewDoplnek).SetData((karta as PPLCG.KartaDoplnek).Doplnek); 
                        break;
                    case PPLCG.ETypy.Hrdina: (grid1.Children[0] as ViewHrdina).SetData((karta as PPLCG.KartaHrdina).Hrdina); 
                        break;
                    case PPLCG.ETypy.Lokace: (grid1.Children[0] as ViewLokace).SetData((karta as PPLCG.KartaLokace).Lokace); 
                        break;
                    case PPLCG.ETypy.Nepritel: (grid1.Children[0] as ViewNepritel).SetData((karta as PPLCG.KartaNepritel).Nepritel); 
                        break;
                    case PPLCG.ETypy.Spojenec: (grid1.Children[0] as ViewSpojenec).SetData((karta as PPLCG.KartaSpojenec).Spojenec); 
                        break;
                    case PPLCG.ETypy.Udalost: (grid1.Children[0] as ViewUdalost).SetData((karta as PPLCG.KartaUdalost).Udalost); 
                        break;
                    case PPLCG.ETypy.Zrada: (grid1.Children[0] as ViewZrada).SetData((karta as PPLCG.KartaZrada).Zrada); 
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
                    grid1.Children.Add(new ViewSpojenec());
                    break;
                case 1:
                    grid1.Children.Add(new ViewDoplnek());
                    break;
                case 2:
                    grid1.Children.Add(new ViewUdalost());
                    break;
                case 3:
                    ViewLokace l = new ViewLokace();
                    l.Init(stiny);
                    grid1.Children.Add(l);
                    break;
                case 4:
                    ViewZrada z = new ViewZrada();
                    z.Init(stiny);
                    grid1.Children.Add(z);
                    break;
                case 5:
                    ViewNepritel n = new ViewNepritel();
                    n.Init(stiny);
                    grid1.Children.Add(n);
                    break;
                case 6:
                    grid1.Children.Add(new ViewHrdina());
                    break;
            }
        }
    }
}
