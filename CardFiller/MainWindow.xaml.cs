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

            Button tlacitko = new Button()
            {
                Content = "Nová karta",
            };
            tlacitko.Click += new RoutedEventHandler(NovaKarta);
            stackPanelTlacitka.Children.Add(tlacitko);
            tlacitko = new Button()
            {
                Content = "Uprav kartu",
            };
            tlacitko.Click += new RoutedEventHandler(UpravKartu);
            stackPanelTlacitka.Children.Add(tlacitko);
            tlacitko = new Button()
            {
                Content = "Smaž kartu",
            };
            tlacitko.Click += new RoutedEventHandler(DelKartu); 
            stackPanelTlacitka.Children.Add(tlacitko);
            tlacitko = new Button()
            {
                Content = "Gen akce",
            };
            tlacitko.Click += new RoutedEventHandler(NewAkce);
            stackPanelTlacitka.Children.Add(tlacitko); 
            tlacitko = new Button()
            {
                Content = "Gen stíny",
            };
            tlacitko.Click += new RoutedEventHandler(NewStiny);
            stackPanelTlacitka.Children.Add(tlacitko);
            tlacitko = new Button()
            {
                Content = "Gen druhy",
            };
            tlacitko.Click += new RoutedEventHandler(NewDruhy);
            stackPanelTlacitka.Children.Add(tlacitko);
            tlacitko = new Button()
            {
                Content = "Přidej akci",
            };
            tlacitko.Click += new RoutedEventHandler(AddAkce);
            stackPanelTlacitka.Children.Add(tlacitko);
            tlacitko = new Button()
            {
                Content = "Smaž akci",
            };
            tlacitko.Click += new RoutedEventHandler(DelAkce);
            stackPanelTlacitka.Children.Add(tlacitko);
            tlacitko = new Button()
            {
                Content = "Smaž stín",
            };
            tlacitko.Click += new RoutedEventHandler(DelStin);
            stackPanelTlacitka.Children.Add(tlacitko);
            tlacitko = new Button()
            {
                Content = "Smaž druh",
            };
            tlacitko.Click += new RoutedEventHandler(DelDruh);
            stackPanelTlacitka.Children.Add(tlacitko);
            tlacitko = new Button()
            {
                Content = "Nahraj karty",
            };
            tlacitko.Click += new RoutedEventHandler(LoadKarty);
            stackPanelTlacitka.Children.Add(tlacitko);
            tlacitko = new Button()
            {
                Content = "Ulož karty",
            };
            tlacitko.Click += new RoutedEventHandler(SaveKarty);
            stackPanelTlacitka.Children.Add(tlacitko);
        }
        List<PPLCG.IKarta> Karty = new List<PPLCG.IKarta>();
        List<PPLCG.Druhy> ListDruhy = new List<PPLCG.Druhy>();
        List<PPLCG.Reakce> ListReakce = new List<PPLCG.Reakce>();
        List<PPLCG.Stiny> ListStiny = new List<PPLCG.Stiny>();
        List<string> Reakce = new List<string>();
        List<string> Stiny = new List<string>();
        List<string> Druhy = new List<string>();
        private void NovaKarta(object sender, RoutedEventArgs e)
        {
            KartaOkno ko = new KartaOkno();
            ko.Init(Reakce, Stiny);
            if (ko.ShowDialog().Value)
            {
                PPLCG.IKarta k = ko.GetKartu();
                Karty.Add(k);
                listBox1.Items.Add(new Label()
                {
                    Content = k.Karta.Id,
                });
                SelectLast();
                Actualize(k);
            }

        }

        private void NewKarta(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Clear();
            foreach (PPLCG.IKarta k in Karty) listBox1.Items.Add(new Label()
            {
                Content = k.Karta.Id,
            });
        }
        public void SelectLast()
        {
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }
        public void SelectLast(ListBox l)
        {
           if(l.Items.Count>0) l.SelectedIndex = l.Items.Count - 1;
        }
        public void Actualize()
        {
            foreach (PPLCG.IKarta k in Karty)
            {
                if (!Druhy.Contains(k.Karta.Druh)) Druhy.Add(k.Karta.Druh);
                foreach (string s in k.Karta.Reakce)
                    if (!Reakce.Contains(s)) Reakce.Add(s);
                if (k is PPLCG.KartaNepritel) foreach (string s in (k as PPLCG.KartaNepritel).Nepritel.Stin)
                        if (!Stiny.Contains(s)) Stiny.Add(s);
                if (k is PPLCG.KartaLokace) foreach (string s in (k as PPLCG.KartaLokace).Lokace.Stin)
                        if (!Stiny.Contains(s)) Stiny.Add(s);
                if (k is PPLCG.KartaZrada) foreach (string s in (k as PPLCG.KartaZrada).Zrada.Stin)
                        if (!Stiny.Contains(s)) Stiny.Add(s);
            }
            NewKarta(null, null);
            NewAkce(null, null);
            NewDruhy(null, null);
            NewStiny(null, null);

        }
        public void Actualize(PPLCG.IKarta k)
        {
            if (!Druhy.Contains(k.Karta.Druh)) Druhy.Add(k.Karta.Druh);
            foreach (string s in k.Karta.Reakce)
                if (!Reakce.Contains(s)) Reakce.Add(s);
            if (k is PPLCG.KartaNepritel) foreach (string s in (k as PPLCG.KartaNepritel).Nepritel.Stin)
                    if (!Stiny.Contains(s)) Stiny.Add(s);
            if (k is PPLCG.KartaLokace) foreach (string s in (k as PPLCG.KartaLokace).Lokace.Stin)
                    if (!Stiny.Contains(s)) Stiny.Add(s);
            if (k is PPLCG.KartaZrada) foreach (string s in (k as PPLCG.KartaZrada).Zrada.Stin)
                    if (!Stiny.Contains(s)) Stiny.Add(s);
            NewAkce(null,null);
            NewDruhy(null, null);
            NewStiny(null, null);

        }
        private void UpravKartu(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                KartaOkno ko = new KartaOkno(Karty[listBox1.SelectedIndex]);
                ko.Init(Reakce, Stiny);
                if (ko.ShowDialog().Value)
                {
                    PPLCG.IKarta k = ko.GetKartu();
                    Karty[listBox1.SelectedIndex] = k;
                    Actualize(k);
                }
            }
        }
        private void DelKartu(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Karty.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                SelectLast();
            }
        }

        private void AddAkce(object sender, RoutedEventArgs e)
        {
            MyListWindow mlw = new MyListWindow();
            mlw.Jmeno = "Reakce";
            mlw.myListControl1.Add();
            if (mlw.ShowDialog().Value)
            {
                foreach (string s in mlw.myListControl1.GetSelected())
                {
                    if (!Reakce.Contains(s))
                    {
                        Reakce.Add(s);
                        listBoxReakce.Items.Add(s);
                    }
                }
                SelectLast(listBoxReakce);
            }
           
        }

        private void LoadKarty(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] data = Directory.GetFiles(fbd.SelectedPath);
                Karty.Clear();
                foreach (string s in data)
                {
                    if (s.Contains(".pk"))
                    {
                        //FileStream f = File.Create(s);
                        Nini.Config.IniConfigSource source = new Nini.Config.IniConfigSource(s);
                        PPLCG.IKarta k = CreateIKarta(source);
                        if (k != null)
                        {
                            if (k.Load(source)) Karty.Add(k);
                        }
                        source.Save();
                    }
                }
                Actualize();
            }

        }
        private PPLCG.IKarta CreateIKarta(Nini.Config.IniConfigSource source)
        {
            if (source.Configs.Count != 2) return null;
            switch(source.Configs[1].Name)
            {
                case "Hrdina": return new PPLCG.KartaHrdina();
                case "Doplnek": return new PPLCG.KartaDoplnek();
                case "Lokace": return new PPLCG.KartaLokace();
                case "Nepritel": return new PPLCG.KartaNepritel();
                case "Spojenec": return new PPLCG.KartaSpojenec();
                case "Udalost": return new PPLCG.KartaUdalost();
                case "Zrada": return new PPLCG.KartaZrada();
                default: return null;
            }
        }
        private void DelAkce(object sender, RoutedEventArgs e)
        {
            if (listBoxReakce.SelectedIndex != -1)
            {
                Reakce.RemoveAt(listBoxReakce.SelectedIndex);
                listBoxReakce.Items.RemoveAt(listBoxReakce.SelectedIndex);
                SelectLast(listBoxReakce);
            }
        }

        private void DelStin(object sender, RoutedEventArgs e)
        {
            if (listBoxStiny.SelectedIndex != -1)
            {
                Stiny.RemoveAt(listBoxStiny.SelectedIndex);
                listBoxStiny.Items.RemoveAt(listBoxStiny.SelectedIndex);
                SelectLast(listBoxStiny);
            }
        }
        private void DelDruh(object sender, RoutedEventArgs e)
        {
            if (listBoxDruhy.SelectedIndex != -1)
            {
                Druhy.RemoveAt(listBoxDruhy.SelectedIndex);
                listBoxDruhy.Items.RemoveAt(listBoxDruhy.SelectedIndex);
                SelectLast(listBoxDruhy);
            }
        }

        private void NewAkce(object sender, RoutedEventArgs e)
        {
            listBoxReakce.Items.Clear();
            Reakce.Sort();
            foreach (string s in Reakce) listBoxReakce.Items.Add(s);
        }
        private void NewDruhy(object sender, RoutedEventArgs e)
        {
            listBoxDruhy.Items.Clear();
            Druhy.Sort();
            foreach (string s in Druhy) listBoxDruhy.Items.Add(s);
        }
        private void NewStiny(object sender, RoutedEventArgs e)
        {
            listBoxStiny.Items.Clear();
            Stiny.Sort();
            foreach (string s in Stiny) listBoxStiny.Items.Add(s);
        }

        private void SaveKarty(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (PPLCG.IKarta k in Karty)
                {
                    string path = fbd.SelectedPath + "/" + k.Karta.Id + ".pk";
                    FileStream f = File.Create(path);
                    f.Close();
                    Nini.Config.IniConfigSource source = new Nini.Config.IniConfigSource(path);
                    k.Save(source);
                    source.Save();
                }
            }
        }
    }
}
