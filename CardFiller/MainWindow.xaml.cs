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
using System.IO;

namespace CardFiller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (Properties.Settings.Default.LokaceKaret == null || Properties.Settings.Default.LokaceKaret == "")
            {
                System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Properties.Settings.Default.LokaceKaret = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                }
                else Close();
            }
            LoadKarty(Properties.Settings.Default.LokaceKaret);

        }
        List<AKarta> Karty = new List<AKarta>();
        private void NovaKarta(object sender, RoutedEventArgs e)
        {
            KartaVyber kv = new KartaVyber();
            if (kv.ShowDialog().Value)
            {
                KartaOkno ko = new KartaOkno();
                ko.Init(kv.Karta);
                if (ko.ShowDialog().Value)
                {
                    Karty.Add(kv.Karta);
                    listBox1.Items.Add(new Label()
                    {
                        Content = kv.Karta.Karta.Id,
                    });
                    SelectLast();
                }
            }
            else return;

        }
        
        public void SelectLast()
        {
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }
        public void SelectLast(ListBox l)
        {
           if(l.Items.Count>0) l.SelectedIndex = l.Items.Count - 1;
        }
        private void DelKartu(object sender, RoutedEventArgs e)
        {
            string cesta = Properties.Settings.Default.LokaceKaret + "/" + listBox1.SelectedItem + ".pk";
            if (File.Exists(cesta))
            {
                File.Delete(cesta);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }
        
        private void LoadKarty(string cesta)
        {
            if (!Directory.Exists(cesta)) return;
                string[] data = Directory.GetFiles(cesta);
            Karty.Clear();
            foreach (string s in data)
            {
                if (s.Contains(".pk"))
                {
                    //FileStream f = File.Create(s);
                    Nini.Config.IniConfigSource source = new Nini.Config.IniConfigSource(s);
                    PPLCG.DataKarta dataKarta = new PPLCG.DataKarta();
                    AKarta k = null;
                    Nini.Config.IConfig config = source.Configs["Karta"];
                    if(config!=null) dataKarta.Load(config);
                    switch(dataKarta.Typ)
                    {
                        case PPLCG.ETypy.Doplnek:
                            PPLCG.DataDoplnek dd = new PPLCG.DataDoplnek();
                            dd.Load(config);
                            k = new KartaDoplnek(dd);
                            break;
                        case PPLCG.ETypy.Hrdina:
                            PPLCG.DataHrdina dh = new PPLCG.DataHrdina();
                            dh.Load(config);
                            k = new KartaHrdina(dh);
                            break;
                        case PPLCG.ETypy.Lokace:
                            PPLCG.DataLokace dl = new PPLCG.DataLokace();
                            dl.Load(config);
                            k = new KartaLokace(dl);
                            break;
                        case PPLCG.ETypy.Nepritel:
                            PPLCG.DataNepritel dn = new PPLCG.DataNepritel();
                            dn.Load(config);
                            k = new KartaNepritel(dn);
                            break;
                        case PPLCG.ETypy.Spojenec:
                            PPLCG.DataSpojenec ds = new PPLCG.DataSpojenec();
                            ds.Load(config);
                            k = new KartaSpojenec(ds);
                            break;
                        case PPLCG.ETypy.Udalost:
                            PPLCG.DataUdalost du = new PPLCG.DataUdalost();
                            du.Load(config);
                            k = new KartaUdalost(du);
                            break;
                        case PPLCG.ETypy.Zrada:
                            PPLCG.DataZrada dz = new PPLCG.DataZrada();
                            dz.Load(config);
                            k = new KartaZrada(dz);
                            break;
                    }
                    if (k != null)
                    {
                        Karty.Add(k);
                        listBox1.Items.Add(k.Karta.Id);
                    }
                }
            }
        }

        private void SaveKarty(object sender, RoutedEventArgs e)
        {
            string cesta = Properties.Settings.Default.LokaceKaret;
            foreach (AKarta k in Karty)
            {
                string path = cesta + "/" + k.Karta.Id + ".pk";
                FileStream f = File.Create(path);
                f.Close();
                Nini.Config.IniConfigSource source = new Nini.Config.IniConfigSource(path);
                source.AddConfig("Karta");
                k.Karta.Save(source.Configs["Karta"]);
                source.Save();
            }
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;
            //ViewKarta vk = new ViewKarta();
            //vk.Init(Karty[listBox1.SelectedIndex] as PPLCG.DataKarta);
            //panelKarta.Content = vk;
            ScrollViewer sv = new ScrollViewer() { Content = Karty[listBox1.SelectedIndex].sp };
            panelKarta.Content = sv;

        }

        private void ActKarty(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();
            foreach(PPLCG.IKarta dk in Karty)
            {
                listBox1.Items.Add(dk.Id);
            }
        }
    }
}
