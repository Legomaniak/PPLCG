using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLCG
{
    public class DataNepritel
    {
        public int Ohrozeni;
        public int Stretnuti;
        public string[] Stin;
        public int Utok;
        public int Obrana;
        public int Zivoty;
        public DataNepritel()
        {
             Ohrozeni = 0;
             Stretnuti = 0;
             Utok = 0;
             Obrana = 0;
             Zivoty = 0;
             Stin = new string[1] { "None" };
        }
        public DataNepritel(string[] stin, int zivoty, int utok, int obrana, int ohrozeni, int stretnuti)
        {
            Ohrozeni = ohrozeni;
            Utok = utok;
            Obrana = obrana;
            Zivoty = zivoty;
            Stin = stin;
            Stretnuti = stretnuti;
        }
        public bool Save(Nini.Config.IConfigSource source)
        {
            Nini.Config.IConfig config = source.AddConfig("Nepritel");
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
                return false;
            }
            else return true;
        }
        public bool Load(Nini.Config.IConfigSource source)
        {
            Nini.Config.IConfig config = GetConfig(source, "Nepritel");
            if (config != null)
            {
                Ohrozeni = config.GetInt("Ohrozeni");
                Stretnuti = config.GetInt("Stretnuti");
                Utok = config.GetInt("Utok");
                Obrana = config.GetInt("Obrana");
                Zivoty = config.GetInt("Zivoty");
                string s = config.GetString("Stiny");
                string[] Stin = s.Split(',');
                return false;
            }
            else return true;
        }
        public Nini.Config.IConfig GetConfig(Nini.Config.IConfigSource source, string nameConfig)
        {
            if (source.Configs[1].Name == nameConfig) return source.Configs[nameConfig];
            else return null;
        }
    }
}
