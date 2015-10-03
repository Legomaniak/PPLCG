using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLCG
{
    public class DataHrdina:DataKarta
    {
        public int Hrozba
        {
            get { return _Hrozba; }
            set { _Hrozba = value; OnPropertyChanged("Hrozba"); }
        }
        int _Hrozba = 0;
        public int Vule
        {
            get { return _Vule; }
            set { _Vule = value; OnPropertyChanged("Vule"); }
        }
        int _Vule = 0;
        public int Utok
        {
            get { return _Utok; }
            set { _Utok = value; OnPropertyChanged("Utok"); }
        }
        int _Utok = 0;
        public int Obrana
        {
            get { return _Obrana; }
            set { _Obrana = value; OnPropertyChanged("Obrana"); }
        }
        int _Obrana = 0;
        public int Zivoty
        {
            get { return _Zivoty; }
            set { _Zivoty = value; OnPropertyChanged("Zivoty"); }
        }
        int _Zivoty = 0;
        public DataHrdina()
        {
            Hrozba = 0;
            Vule = 0;
            Utok = 0;
            Obrana = 0;
            Zivoty = 0;
            Typ = ETypy.Hrdina;
        }
        public DataHrdina(DataKarta dk, int zivoty, int utok, int obrana, int vule, int hrozba) : base(dk)
        {
            Hrozba = hrozba;
            Vule = vule;
            Utok = utok;
            Obrana = obrana;
            Zivoty = zivoty;
        }
        public override EReturn Save(Nini.Config.IConfig config)
        {
            base.Save(config);
            //Nini.Config.IConfig config = source.AddConfig("Hrdina");
            if (config != null)
            {
                config.Set("Hrozba", Hrozba);
                config.Set("Vule", Vule);
                config.Set("Utok", Utok);
                config.Set("Obrana", Obrana);
                config.Set("Zivoty", Zivoty);
                return EReturn.NoError;
            }
            else return EReturn.Error;
        }
        public override EReturn Load(Nini.Config.IConfig config)
        {
            base.Load(config);
            //Nini.Config.IConfig config = GetConfig(source, "Hrdina");
            if (config != null)
            {
                Hrozba = config.GetInt("Hrozba");
                Vule = config.GetInt("Vule");
                Utok = config.GetInt("Utok");
                Obrana = config.GetInt("Obrana");
                Zivoty = config.GetInt("Zivoty");
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
