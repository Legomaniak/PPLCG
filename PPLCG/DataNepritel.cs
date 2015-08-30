using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLCG
{
    public class DataNepritel:DataKarta
    {
        public int Ohrozeni
        {
            get { return _Ohrozeni; }
            set { _Ohrozeni = value; OnPropertyChanged("Ohrozeni"); }
        }
        int _Ohrozeni = 0;
        public int Stretnuti
        {
            get { return _Stretnuti; }
            set { _Stretnuti = value; OnPropertyChanged("Stretnuti"); }
        }
        int _Stretnuti = 0;
        public string[] Stin
        {
            get { return _Stin; }
            set { _Stin = value; OnPropertyChanged("Stin"); }
        }
        string[] _Stin;
        public int Utok
        {
            get { return _Utok; }
            set { _Utok = value; OnPropertyChanged("Utok"); }
        }
        int _Utok = 0;
        public int Obrana
        {
            get { return _Obrana; }
            set { _Obrana = value; OnPropertyChanged("Obrana"); }
        }
        int _Obrana = 0;
        public int Zivoty
        {
            get { return _Zivoty; }
            set { _Zivoty = value; OnPropertyChanged("Zivoty"); }
        }
        int _Zivoty = 0;
        public DataNepritel()
        {
             Ohrozeni = 0;
             Stretnuti = 0;
             Utok = 0;
             Obrana = 0;
             Zivoty = 0;
             Stin = new string[1] { "None" };
        }
        public DataNepritel(DataKarta dk, string[] stin, int zivoty, int utok, int obrana, int ohrozeni, int stretnuti) : base(dk)
        {
            Ohrozeni = ohrozeni;
            Utok = utok;
            Obrana = obrana;
            Zivoty = zivoty;
            Stin = stin;
            Stretnuti = stretnuti;
        }
        public override EReturn Save(Nini.Config.IConfig config)
        {
            base.Save(config);
            //Nini.Config.IConfig config = source.AddConfig("Nepritel");
            if (config != null)
            {
                config.Set("Ohrozeni", Ohrozeni);
                config.Set("Stretnuti", Stretnuti);
                config.Set("Utok", Utok);
                config.Set("Obrana", Obrana);
                config.Set("Zivoty", Zivoty);
                string s = "";
                foreach (string ss in Stin) if (s == "") s = ss;
                    else s = s + "," + ss;
                config.Set("Stiny", s);
                return EReturn.NoError;
            }
            else return EReturn.Error;
        }
        public override EReturn Load(Nini.Config.IConfig config)
        {
            base.Load(config);
            //Nini.Config.IConfig config = GetConfig(source, "Nepritel");
            if (config != null)
            {
                Ohrozeni = config.GetInt("Ohrozeni");
                Stretnuti = config.GetInt("Stretnuti");
                Utok = config.GetInt("Utok");
                Obrana = config.GetInt("Obrana");
                Zivoty = config.GetInt("Zivoty");
                string s = config.GetString("Stiny");
                string[] Stin = s.Split(',');
                return EReturn.NoError;
            }
            else return EReturn.Error;
        }
    }
}
