using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLCG
{
    public class DataZrada:DataKarta
    {
        public List<MyString> Stin
        {
            get { return _Stin; }
            set { _Stin = value; OnPropertyChanged("Stin"); }
        }
        List<MyString> _Stin;
        public DataZrada()
        {
            Stin = new List<MyString>();
            Typ = ETypy.Zrada;
        }
        public DataZrada(DataKarta dk, List<MyString> stin) : base(dk)
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
                foreach (MyString ss in Stin)
                    if (s == "") s = ss.String;
                    else s = s + "," + ss.String;
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
                string[] stin = s.Split(',');
                List<MyString> mujList = new List<MyString>();
                foreach (string ss in stin)
                {
                    MyString ms = new MyString();
                    ms.String = ss;
                    mujList.Add(ms);
                }
                Stin = mujList;
                return EReturn.NoError;
            }
            else return EReturn.Error;
        }
    }
}
