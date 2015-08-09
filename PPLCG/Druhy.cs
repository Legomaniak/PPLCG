using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLCG
{
    public class Druhy
    {
        List<string> druhy = new List<string>();
        public bool Add(string druh)
        {
            if (druhy.Contains(druh)) return true;
            druhy.Add(druh);
            return false;
        }
        public bool Contains(string druh) { return druhy.Contains(druh); }
        public void remove(string druh)
        {
            if (druhy.Contains(druh)) druhy.Remove(druh);
        }
        public void Clear() { druhy.Clear(); }
        public string[] GetDruhy()
        {
            return druhy.ToArray();
        }
        public void Load(Nini.Config.IConfigSource source)
        {
            if (source.Configs.Contains("Druhy"))
            {
                Nini.Config.IConfig config = source.Configs["Druhy"];
                string s = config.GetString("Všechny druhy");
                string[] ss = s.Split(',');
                foreach (string sss in ss) druhy.Add(sss);
            }
        }
        public void Save(Nini.Config.IConfigSource source)
        {
            Nini.Config.IConfig config = source.AddConfig("Druhy");
            string s = "";
            foreach (string ss in druhy) if (s == "") s = ss;
                else s = s + "," + ss;
            config.Set("Všechny druhy", s);
        }
    }
    
}
