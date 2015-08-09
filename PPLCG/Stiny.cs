using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLCG
{
    public class Stiny
    {
        List<string> stiny = new List<string>();
        public bool Add(string stin)
        {
            if (stiny.Contains(stin)) return true;
            stiny.Add(stin);
            return false;
        }
        public bool Contains(string stin) { return stiny.Contains(stin); }
        public void remove(string stin)
        {
            if (stiny.Contains(stin)) stiny.Remove(stin);
        }
        public void Clear() { stiny.Clear(); }
        public string[] GetStiny()
        {
            return stiny.ToArray();
        }
        public void Load(Nini.Config.IConfigSource source)
        {
            if (source.Configs.Contains("Stiny"))
            {
                Nini.Config.IConfig config = source.Configs["Stiny"];
                string s = config.GetString("Všechny stiny");
                string[] ss = s.Split(',');
                foreach (string sss in ss) stiny.Add(sss);
            }
        }
        public void Save(Nini.Config.IConfigSource source)
        {
            Nini.Config.IConfig config = source.AddConfig("Stiny");
            string s = "";
            foreach (string ss in stiny) if (s == "") s = ss;
                else s = s + "," + ss;
            config.Set("Všechny stiny", s);
        }
    }
}
