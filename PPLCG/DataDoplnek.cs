using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLCG
{
    public class DataDoplnek : DataKarta
    {
        public int Cena
        {
            get { return _Cena; }
            set { _Cena = value; OnPropertyChanged("Cena"); }
        }
        int _Cena = 0;
        public DataDoplnek()
        {
            Cena = 0;
        }
        public DataDoplnek(DataKarta dk, int cena) : base(dk)
        { 
            Cena = cena;
        }
        public override EReturn Save(Nini.Config.IConfig config)
        {
            base.Save(config);
            //Nini.Config.IConfig config = source.AddConfig("Doplnek");
            if (config != null)
            {
                config.Set("Cena", Cena);
                return EReturn.NoError;
            }
            else return EReturn.Error;
        }
        public override EReturn Load(Nini.Config.IConfig config)
        {
            base.Load(config);
            //Nini.Config.IConfig config = GetConfig(source, "Doplnek");
            if (config != null)
            {
                Cena = config.GetInt("Cena");
                return EReturn.NoError;
            }
            else return EReturn.Error;
        }
        //public Nini.Config.IConfig GetConfig(Nini.Config.IConfigSource source, string nameConfig)
        //{
        //    if (source.Configs[1].Name == nameConfig) return source.Configs[nameConfig];
        //    else return null;
        //}
    }
}
