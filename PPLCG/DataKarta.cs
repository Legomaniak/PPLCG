using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nini.Config;

namespace PPLCG
{
    public class DataKarta
    {
        public string Id;
        public string Jmeno;
        public string Popis;
        public Citace Citace;
        public Sfery Sfera;
        public Typy Typ;
        public bool Kvalita;
        public string[] Reakce;
        public string Druh;
        public bool IsValid = false;
        public DataKarta()
        {
            Id = "K0";
            Jmeno = "Karta";
            Popis = "Prazdná karta";
            Sfera = Sfery.Neutralni;
            Typ = Typy.Spojenec;
            Kvalita = false;
            Reakce = new string[1] { "None" };
            Druh = "None";
            Citace = new Citace();
        }
        public DataKarta(string id, string jmeno, string popis, Sfery sfera, Typy typ, bool kvalita, string[] reakce, string druh, Citace citace)
        {
            Id = id;
            Jmeno = jmeno;
            Popis = popis;
            Sfera = sfera;
            Typ = typ;
            Kvalita = kvalita;
            Reakce = reakce;
            Druh = druh;
            Citace = citace;
        }
        public bool Save(IConfigSource source)
        {
            IConfig config = source.AddConfig("Karta");
            if (config != null)
            {
                config.Set("ID", Id);
                config.Set("Jmeno", Jmeno);
                config.Set("Popis", Popis);
                config.Set("Sfera", (int)Sfera);
                config.Set("Typ", (int)Typ);
                config.Set("Druh", Druh);
                if (Citace.Save(config)) Console.WriteLine("Error save citace");
                string s = "";
                foreach (string ss in Reakce) if(s=="") s = ss;
                    else s = s + "," + ss;
                config.Set("Reakce", s);
                return false;
            }
            else return true;
        }
        public bool Load(IConfigSource source)
        {            
            IConfig config = GetConfig(source, "Karta");
            if (config != null)
            {
                Id = config.GetString("ID");
                Jmeno = config.GetString("Jmeno");
                Popis = config.GetString("Popis");
                Sfera = (Sfery)config.GetInt("Sfera");
                Typ = (Typy)config.GetInt("Typ");
                Popis = config.GetString("Druh");
                string s = config.GetString("Reakce");
                string[] Reakce = s.Split(',');
                return false;
            }
            else return true;
        }
        public IConfig GetConfig(IConfigSource source, string nameConfig)
        {
            if (source.Configs[0].Name == nameConfig) return source.Configs[nameConfig];
            else return null;
        }
    }
}
