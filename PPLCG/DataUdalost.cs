using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLCG
{
    public class DataUdalost
    {
        public int Cena;
        public DataUdalost()
        {
            Cena = 0;
        }
        public DataUdalost(int cena)
        {
            Cena = cena;
        }
        public bool Save(Nini.Config.IConfigSource source)
        {
            Nini.Config.IConfig config = source.AddConfig("Udalost");
            if (config != null)
            {
                config.Set("Cena", Cena);
                return false;
            }
            else return true;
        }
        public bool Load(Nini.Config.IConfigSource source)
        {
            Nini.Config.IConfig config = GetConfig(source, "Udalost");
            if (config != null)
            {
                Cena = config.GetInt("Cena");
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
