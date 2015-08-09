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
using System.Windows.Forms;

namespace PPLCG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<DataKarta> Karty = new List<DataKarta>();
        public MainWindow()
        {
            InitializeComponent();
            /*Karty.Add(new KartaSpojenec("K1","Gandalf", "Na konci kola, odhod gandalfa ze hry; reakce: pote co vstoupi do hry zvol jednu moznost: vezmi si tri karty, udel 4 poskozeni jednomu nepriteli, sniz svoje ohrozeni o 5", Sfery.Neutralni, Kvality.Jedinecna, new Reakce[] { Reakce.BerKarty3, Reakce.SnizOhrozeni5, Reakce.OdstranNaKonciKola, Reakce.UdelPoskozeni4 }, 4, 4, 4, 4, 5));
            Karty.Add(new KartaNepritel("K2", "Hlídka z východního zářezu", "Goblin a skřet", Kvality.Normalni, new Reakce[] { PPLCG.Reakce.none }, new Stiny[] { PPLCG.Stiny.Utok1 }, 2, 3, 1, 3, 5));
            Karty.Add(new KartaUdalost("K3", "Chodcova stezka", "Pote co je z balicku setkani odhaleena lokace. ihned doni cesstujte, ale nprovadejte effekt putovani. Pokud je prave aktivni jina lokace, vratte ji do lokace odhaleni", Kvality.Normalni, new Reakce[] { PPLCG.Reakce.OdhaleniLokace }, 1));
            Karty.Add(new KartaDoplnek("K4"));
            Karty.Add(new KartaHrdina("K5"));
            Karty.Add(new KartaLokace("K6"));
            Karty.Add(new KartaZrada("K7"));
            */
        }
        private void Load_Click(object sender, RoutedEventArgs e)
        {
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
        }
        //private void Load_Click(object sender, RoutedEventArgs e)
        //{
        //    string s = null;
        //    List<string> cesty = new List<string>();
        //    FolderBrowserDialog fbd = new FolderBrowserDialog();
        //    DialogResult result = fbd.ShowDialog(); // Show the dialog.
        //    if (result == System.Windows.Forms.DialogResult.OK) // Test result.
        //    {
        //        s = fbd.SelectedPath;
        //    }

        //    if (s == null) return;
        //    foreach (string ss in Directory.GetFiles(s + "/", "*.pk"))
        //    {
        //        cesty.Add(ss);
        //    }
        //    if (cesty.Count < 1) return;
        //    foreach (string c in cesty)
        //    {
        //        StreamReader sr = new StreamReader(c);
        //        string radek = sr.ReadLine();
        //        KartaDoplnek kd = new KartaDoplnek();
        //        KartaHrdina kh = new KartaHrdina();
        //        KartaLokace kl = new KartaLokace();
        //        KartaNepritel kn = new KartaNepritel();
        //        KartaSpojenec ks = new KartaSpojenec();
        //        KartaUdalost ku = new KartaUdalost();
        //        KartaZrada kz = new KartaZrada();
        //        do
        //        {
        //            if (radek.ToCharArray()[0] != '#')
        //            {
        //                string[] poles = radek.Split('=');
        //                if (poles.Length != 2)
        //                {
        //                    Console.WriteLine("Špatná hodnota(=) v kartě: " + c.ToString());
        //                    Console.WriteLine("Na řádku: " + radek.ToString());
        //                }
        //                if (poles.Length < 2) return;
        //                else
        //                {
        //                    string jmeno = poles[0].Replace(" ", "");
        //                    if (jmeno == "Typ")
        //                    {
        //                        switch (int.Parse(poles[1]))
        //                        {
        //                            case 0:
        //                                kd = null;
        //                                kh = null;
        //                                kl = null;
        //                                kn = null;
        //                                ku = null;
        //                                kz = null;
        //                                break;
        //                            case 1:
        //                                kh = null;
        //                                kl = null;
        //                                kn = null;
        //                                ks = null;
        //                                ku = null;
        //                                kz = null;
        //                                break;
        //                            case 2:
        //                                kd = null;
        //                                kh = null;
        //                                kl = null;
        //                                kn = null;
        //                                ks = null;
        //                                kz = null;
        //                                break;
        //                            case 3:
        //                                kd = null;
        //                                kh = null;
        //                                kn = null;
        //                                ks = null;
        //                                ku = null;
        //                                kz = null;
        //                                break;
        //                            case 4:
        //                                kd = null;
        //                                kh = null;
        //                                kl = null;
        //                                kn = null;
        //                                ks = null;
        //                                ku = null;
        //                                break;
        //                            case 5:
        //                                kd = null;
        //                                kh = null;
        //                                kl = null;
        //                                ks = null;
        //                                ku = null;
        //                                kz = null;
        //                                break;
        //                            case 6:
        //                                kd = null;
        //                                kl = null;
        //                                kn = null;
        //                                ks = null;
        //                                ku = null;
        //                                kz = null;
        //                                break;
        //                        }
        //                    }
        //                    if (kd != null)
        //                    {
        //                        if (kd.Load(jmeno, poles[1])) Console.WriteLine("Data not found");
        //                    }
        //                    if (kh != null)
        //                    {
        //                        if (kh.Load(jmeno, poles[1])) Console.WriteLine("Data not found");
        //                    }
        //                    if (kl != null)
        //                    {
        //                        if (kl.Load(jmeno, poles[1])) Console.WriteLine("Data not found");
        //                    }
        //                    if (kn != null)
        //                    {
        //                        if (kn.Load(jmeno, poles[1])) Console.WriteLine("Data not found");
        //                    }
        //                    if (ks != null)
        //                    {
        //                        if (ks.Load(jmeno, poles[1])) Console.WriteLine("Data not found");
        //                    }
        //                    if (ku != null)
        //                    {
        //                        if (ku.Load(jmeno, poles[1])) Console.WriteLine("Data not found");
        //                    }
        //                    if (kz != null)
        //                    {
        //                        if (kz.Load(jmeno, poles[1])) Console.WriteLine("Data not found");
        //                    }
        //                }
                        
        //                //textBlock1.Text += radek+"\n";
        //            }
        //            radek = sr.ReadLine();
        //        } while (radek != null);
                
        //        if (kd != null) Karty.Add(kd);
        //        if (kh != null) Karty.Add(kh);
        //        if (kl != null) Karty.Add(kl);
        //        if (kn != null) Karty.Add(kn);
        //        if (ks != null) Karty.Add(ks);
        //        if (ku != null) Karty.Add(ku);
        //        if (kz != null) Karty.Add(kz);
        //    }
        //    /*BitmapImage src = new BitmapImage();
        //    src.BeginInit();
        //    src.UriSource = new Uri(cesty[0], UriKind.Relative);
        //    src.CacheOption = BitmapCacheOption.OnLoad;
        //    src.EndInit();
        //    Obrazek.Source = src;
        //    Obrazek.Stretch = Stretch.Uniform;*/
        //}
        //private void Save_Click(object sender, RoutedEventArgs e)
        //{
        //    string s = null;
        //    //textBlock1.Text = Karty[0].Save();
        //    FolderBrowserDialog fbd = new FolderBrowserDialog();
        //    DialogResult result = fbd.ShowDialog();
        //    if (result == System.Windows.Forms.DialogResult.OK) // Test result.
        //    {
        //        s = fbd.SelectedPath;
        //    }
        //    if (s == null) return;
        //    foreach (Karta k in Karty)
        //    {
        //        using (StreamWriter outfile = new StreamWriter(s + "/" + k.Id + ".pk"))
        //        {
        //            outfile.Write(k.Save());
        //        }
        //    }
        //}
    }
}
