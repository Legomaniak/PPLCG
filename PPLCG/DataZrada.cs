using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLCG
{
    public class DataZrada:DataKarta
    {
        public string[] Stin
        {
            get { return _Stin; }
            set { _Stin = value; OnPropertyChanged("Stin"); }
        }
        string[] _Stin;
        public DataZrada()
        {
            Stin = new string[1] { "None" };
        }
        public DataZrada(DataKarta dk, string[] stin) : base(dk)
        {
            Stin = stin;
        }
        public override EReturn Save(Nini.Config.IConfig config)
        {
            base.Save(config);
            //Nini.Config.IConfig config = source.AddConfig("Zrada");
            if (config != null)
            {
                string s = "";
                foreach (string ss in Stin) if (s == "") s = ss;
                    else s = s + "," + ss;
                config.Set("Stin", s);
                return EReturn.NoError;
            }
            else return EReturn.Error;
        }
        public override EReturn Load(Nini.Config.IConfig config)
        {
            base.Load(config);
            //Nini.Config.IConfig config = GetConfig(source, "Zrada");
            if (config != null)
            {
                string s = config.GetString("Stin");
                string[] Stin = s.Split(',');
                return EReturn.NoError;
            }
            else return EReturn.Error;
        }
    }
}
