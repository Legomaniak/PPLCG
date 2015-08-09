using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLCG
{
    public class DataHrdina
    {
        public int Hrozba;
        public int Vule;
        public int Utok;
        public int Obrana;
        public int Zivoty;
        public DataHrdina()
        {
            Hrozba = 0;
            Vule = 0;
            Utok = 0;
            Obrana = 0;
            Zivoty = 0;
        }
        public DataHrdina(int zivoty, int utok, int obrana, int vule, int hrozba)
        {
            Hrozba = hrozba;
            Vule = vule;
            Utok = utok;
            Obrana = obrana;
            Zivoty = zivoty;
        }
        public bool Save(Nini.Config.IConfigSource source)
        {
            Nini.Config.IConfig config = source.AddConfig("Hrdina");
            if (config != null)
            {
                config.Set("Hrozba", Hrozba);
                config.Set("Vule", Vule);
                config.Set("Utok", Utok);
                config.Set("Obrana", Obrana);
                config.Set("Zivoty", Zivoty);
                return false;
            }
            else return true;
        }
        public bool Load(Nini.Config.IConfigSource source)
        {
            Nini.Config.IConfig config = GetConfig(source, "Hrdina");
            if (config != null)
            {
                Hrozba = config.GetInt("Hrozba");
                Vule = config.GetInt("Vule");
                Utok = config.GetInt("Utok");
                Obrana = config.GetInt("Obrana");
                Zivoty = config.GetInt("Zivoty");
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
