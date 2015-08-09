using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLCG
{
    public class DataDoplnek
    {
        public int Cena;
        public DataDoplnek()
        {
            Cena = 0;
        }
        public DataDoplnek(int cena)
        {
            Cena = cena;
        }
        public bool Save(Nini.Config.IConfigSource source)
        {
            Nini.Config.IConfig config = source.AddConfig("Doplnek");
            if (config != null)
            {
                config.Set("Cena", Cena);
                return false;
            }
            else return true;
        }
        public bool Load(Nini.Config.IConfigSource source)
        {
            Nini.Config.IConfig config = GetConfig(source, "Doplnek");
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
