using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLCG
{
    public class DataZrada
    {
        public string[] Stin;
        public DataZrada()
        {
            Stin = new string[1] { "None" };
        }
        public DataZrada(string[] stin)
        {
            Stin = stin;
        }
        public bool Save(Nini.Config.IConfigSource source)
        {
            Nini.Config.IConfig config = source.AddConfig("Zrada");
            if (config != null)
            {
                string s = "";
                foreach (string ss in Stin) if (s == "") s = ss;
                    else s = s + "," + ss;
                config.Set("Stin", s);
                return false;
            }
            else return true;
        }
        public bool Load(Nini.Config.IConfigSource source)
        {
            Nini.Config.IConfig config = GetConfig(source, "Zrada");
            if (config != null)
            {
                string s = config.GetString("Stin");
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
